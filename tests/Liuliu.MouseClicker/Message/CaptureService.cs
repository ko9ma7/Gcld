﻿using Liuliu.MouseClicker.Models;
using OSharp.Utility.Data;
using PacketDotNet;
using SharpPcap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Message
{
    public class CaptureService
    {
        #region 单例模式实现
        // 定义一个静态变量来保存类的实例
        private static CaptureService uniqueInstance;

        // 定义一个标识确保线程同步
        private static readonly object locker = new object();

        // 定义私有构造函数，使外界不能创建该类实例
        private CaptureService()
        {
        }
        /// <summary>
        /// 定义公有方法提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static CaptureService GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
            // 双重锁定只需要一句判断就可以了
            if (uniqueInstance == null)
            {
                lock (locker)
                {
                    // 如果类的实例不存在则创建，否则直接返回
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new CaptureService();
                    }
                }
            }
            return uniqueInstance;
        }
        #endregion

        private int packetCount;
        private TimeSpan LastStatisticsInterval = new TimeSpan(0, 0, 2);
        private DateTime LastStatisticsOutput;
        private Thread backgroundThread;
        private ICaptureDevice device;
        private bool BackgroundThreadStop;
        private PacketArrivalEventHandler arrivalEventHandler;
        private CaptureStoppedEventHandler captureStoppedEventHandler;
        private object QueueLock = new object();
        private Queue<RawCapture> PacketQueue = new Queue<RawCapture>();
        private Queue<PacketWrapper> packetStrings;
        private Dictionary<string, byte[]> dataBufferDict = new Dictionary<string, byte[]>();
        public void StartCapture(int itemIndex, string filter)
        {
            packetCount = 0;
            device = CaptureDeviceList.Instance[itemIndex];
            packetStrings = new Queue<PacketWrapper>();
            LastStatisticsOutput = DateTime.Now;

            // start the background thread
            BackgroundThreadStop = false;
            backgroundThread = new System.Threading.Thread(BackgroundThread);
            backgroundThread.IsBackground = true;
            backgroundThread.Start();

            // setup background capture
            arrivalEventHandler = new PacketArrivalEventHandler(device_OnPacketArrival);
            device.OnPacketArrival += arrivalEventHandler;
            captureStoppedEventHandler = new CaptureStoppedEventHandler(device_OnCaptureStopped);
            device.OnCaptureStopped += captureStoppedEventHandler;
            device.Open();

            device.Filter = filter;

            Debug.WriteLine("-- 正在监听网卡{0} {1},开始抓包！", device.Name, device.Description);
            // start the background capture
            device.StartCapture();
        }
        private void device_OnCaptureStopped(object sender, CaptureStoppedEventStatus status)
        {
            if (status != CaptureStoppedEventStatus.CompletedWithoutError)
            {
                Debug.WriteLine("Error stopping capture");
            }
        }
        private void BackgroundThread()
        {
            while (!BackgroundThreadStop)
            {
                bool shouldSleep = true;

                lock (QueueLock)
                {
                    if (PacketQueue.Count != 0)
                    {
                        shouldSleep = false;
                    }
                }

                if (shouldSleep)
                {
                    Thread.Sleep(250);
                }
                else // should process the queue
                {
                    RawCapture packet;
                    lock (QueueLock)
                    {
                        packet = PacketQueue.Dequeue();
                    }

                    var packetWrapper = new PacketWrapper(packetCount, packet);

                    var _packet = Packet.ParsePacket(packet.LinkLayerType, packet.Data);

                    var tcpPacket = (TcpPacket)_packet.Extract(typeof(TcpPacket));
                    if (tcpPacket != null)
                    {
                        var ipPacket = (IpPacket)tcpPacket.ParentPacket;
                        IPAddress srcIp = ipPacket.SourceAddress;
                        IPAddress dstIp = ipPacket.DestinationAddress;
                        int srcPort = tcpPacket.SourcePort;
                        int dstPort = tcpPacket.DestinationPort;
                        

                        if (srcIp.ToString() == SoftContext.ServerIp)
                        {
                            string key = string.Format("{0}:{1}->{2}:{3}[Receive]", srcIp.ToString(), srcPort, dstIp.ToString(), dstPort);
                            if (!dataBufferDict.ContainsKey(key))
                                dataBufferDict.Add(key, new byte[] { });
                                ReceivedData(tcpPacket,key);
                        }
                        if (dstIp.ToString() == SoftContext.ServerIp)
                        {
                            string key = string.Format("{0}:{1}->{2}:{3}[Send]", srcIp.ToString(), srcPort, dstIp.ToString(), dstPort);
                            if (!dataBufferDict.ContainsKey(key))
                                dataBufferDict.Add(key, new byte[] { });
                            SendData(tcpPacket,key);
                        }
                    }
                }

            }
        }
       
        private void ReceivedData(TcpPacket tcpPacket,string key)
        {
            byte[] receivedBuffer = dataBufferDict[key];
            Debug.WriteLine("==============================================================================================================");
            Debug.WriteLine("接收数据："+key);
            MsgProtocol msgPro = new MsgProtocol();
            receivedBuffer = CombineBytes.ToArray(receivedBuffer, 0, receivedBuffer.Length, tcpPacket.PayloadData, 0, tcpPacket.PayloadData.Length);
            if (receivedBuffer.Length < 4)
            {
                Debug.WriteLine("receivedBuffer.Length=" + receivedBuffer.Length + "< 4 \t -> \t continue");
                return;
            }
            else
            {
                //取msg包头部分
                msgPro = MsgProtocol.FromBytesR(receivedBuffer);
                if (msgPro == null)
                {
                    Debug.WriteLine("数据格式错误!消息为null"+BitConverter.ToString(tcpPacket.PayloadData));
                    return;
                }
                int msgContentLength = msgPro.MessageLength;
                //判断去掉msg包头剩下的长度是否达到可以取包实质内容
                while ((receivedBuffer.Length - 4) >= msgContentLength)
                {
                    // Debug.WriteLine("【receivedBuffer去掉包头的长度=" + (receivedBuffer.Length - 4) + "】>=【" + "包实质内容长度=" + msgContentLength + "】");
                    msgPro = null;
                    msgPro = MsgProtocol.FromBytesR(receivedBuffer);
                    Debug.WriteLine("【data】=" + "command:" + msgPro.MessageCommand + " token:" + msgPro.MessageToken);
                    Debug.WriteLine("【json】=" + msgPro.Data);

                    //将得到的json字符串转为对象
                    var rootObj = JsonHelper.FromJson<RootObject>(msgPro.Data);

                    if (SoftContext.CommandList.ContainsKey(msgPro.MessageCommand))
                    {
                        SoftContext.CommandList[msgPro.MessageCommand] = rootObj;
                    }
                    else
                    {
                        SoftContext.CommandList.Add(msgPro.MessageCommand, rootObj);
                    }
                    receivedBuffer = msgPro.ExtraBytes;

                    if (receivedBuffer.Length >= 4)
                    {
                        msgPro = MsgProtocol.FromBytesR(receivedBuffer);

                        msgContentLength = msgPro.MessageLength;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
      
        private void SendData(TcpPacket tcpPacket,string key)
        {
            byte[] sendBuffer = dataBufferDict[key];

            if(tcpPacket.PayloadData.Length>0)
            {
                Debug.WriteLine("==============================================================================================================");
                Debug.WriteLine("发送数据："+key);
                MsgProtocol msgPro = new MsgProtocol();
                sendBuffer = CombineBytes.ToArray(sendBuffer, 0, sendBuffer.Length, tcpPacket.PayloadData, 0, tcpPacket.PayloadData.Length);
                if (sendBuffer.Length < 4)
                {
                    Debug.WriteLine("sendBuffer.Length=" + sendBuffer.Length + "< 4 \t -> \t continue");
                    return;
                }
                else
                {
                    //取msg包头部分
                    msgPro = MsgProtocol.FromBytesS(sendBuffer);
                    if (msgPro == null)
                    {
                        Debug.WriteLine("数据格式错误!消息为null"+BitConverter.ToString(tcpPacket.PayloadData));
                        return;
                    }
                    int msgContentLength = msgPro.MessageLength;
                    //判断去掉msg包头剩下的长度是否达到可以取包实质内容
                    while ((sendBuffer.Length - 4) >= msgContentLength)
                    {
                        // Debug.WriteLine("【sendBuffer去掉包头的长度=" + (sendBuffer.Length - 4) + "】>=【" + "包实质内容长度=" + msgContentLength + "】");
                        msgPro = null;
                        msgPro = MsgProtocol.FromBytesS(sendBuffer);
                        Debug.WriteLine("【data】=" + "command:" + msgPro.MessageCommand + " token:" + msgPro.MessageToken);
                        Debug.WriteLine("【param】=" + msgPro.Data);

                        sendBuffer = msgPro.ExtraBytes;

                        if (sendBuffer.Length >= 4)
                        {
                            msgPro = MsgProtocol.FromBytesS(sendBuffer);

                            msgContentLength = msgPro.MessageLength;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

            }
        }


        void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            lock (QueueLock)
            {
                PacketQueue.Enqueue(e.Packet);
            }
        }

        public void Shutdown()
        {
            if (device != null)
            {
                device.StopCapture();
                device.Close();
                device.OnPacketArrival -= arrivalEventHandler;
                device.OnCaptureStopped -= captureStoppedEventHandler;
                device = null;

                // ask the background thread to shut down
                BackgroundThreadStop = true;

                // wait for the background thread to terminate
                backgroundThread.Join();
                Debug.WriteLine("捕获结束！");
            }
        }
    }
}