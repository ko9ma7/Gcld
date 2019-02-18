﻿using Liuliu.MouseClicker.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        private static List<RawCapture> NotProcessedPacketList = new List<RawCapture>();

        private Queue<PacketWrapper> packetStrings;
        private Dictionary<string, byte[]> dataBufferDict = new Dictionary<string, byte[]>();
        public Dictionary<string, CommandCache> CommandCacheDict = new Dictionary<string, CommandCache>();
        public void StartCapture(int itemIndex, string filter)
        {
            packetCount = 0;
            device = CaptureDeviceList.Instance[itemIndex]; //选折网卡
            packetStrings = new Queue<PacketWrapper>();
            LastStatisticsOutput = DateTime.Now;

            // start the background thread
            BackgroundThreadStop = false;
            backgroundThread = new Thread(BackgroundThread);
            backgroundThread.IsBackground = true;
            backgroundThread.Start();

            // setup background capture
            arrivalEventHandler = new PacketArrivalEventHandler(device_OnPacketArrival);//当包抵达时要进行的操作
            device.OnPacketArrival += arrivalEventHandler;
            captureStoppedEventHandler = new CaptureStoppedEventHandler(device_OnCaptureStopped); //停止抓包要做的操作
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
            Debug.WriteLine("stopping capture");
        }

        void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            lock (QueueLock)
            {
                NotProcessedPacketList.Add(e.Packet);
            }
        }
        private void BackgroundThread()
        {
            while (!BackgroundThreadStop)
            {
                bool shouldSleep = true;

                lock (QueueLock)
                {
                    if (NotProcessedPacketList.Count != 0)
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
                    //获取当前待处理封包列表
                    List<RawCapture> ourPacketList;
                    lock (QueueLock)
                    {
                        ourPacketList = NotProcessedPacketList;
                        NotProcessedPacketList = new List<RawCapture>();
                    }

                    #region 进行封包处理
                    foreach (var packet in ourPacketList)
                    {
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

                            try
                            {
                                //收到封包处理
                                if (srcIp.ToString() == SoftContext.ServerIp && srcPort == 8220)
                                {
                                    string key = string.Format("{0}:{1}->{2}:{3}[Receive]", srcIp.ToString(), srcPort, dstIp.ToString(), dstPort);
                                    string key2 = string.Format("{0}:{1}", dstIp, dstPort);
                                    if (!dataBufferDict.ContainsKey(key))   //当发现新的接收方则添加新的接收缓冲区
                                    {
                                        dataBufferDict.Add(key, new byte[] { });
                                        if (!CommandCacheDict.ContainsKey(key2))
                                            CommandCacheDict.Add(key2, new CommandCache());
                                    }
                                    ReceivedData(tcpPacket, key,key2);
                                }
                                //发送封包处理
                                if (dstIp.ToString() == SoftContext.ServerIp)
                                {
                                    string key = string.Format("{0}:{1}->{2}:{3}[Send]", srcIp.ToString(), srcPort, dstIp.ToString(), dstPort);
                                    string key2 = string.Format("{0}:{1}", srcIp, srcPort);
                                    if (!dataBufferDict.ContainsKey(key))  //当发现新的发送方则添加新的发送缓冲区
                                    {
                                        dataBufferDict.Add(key, new byte[] { });
                                        if (!CommandCacheDict.ContainsKey(key2))
                                            CommandCacheDict.Add(key2, new CommandCache());
                                    }
                                    SendData(tcpPacket, key,key2);
                                }
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex.Message + ex.StackTrace);
                            }
                        }
                    }
                    #endregion
                }

            }
        }
       
        private void ReceivedData(TcpPacket tcpPacket,string key,string key2)
        {
            MsgProtocol msgPro = new MsgProtocol();
            dataBufferDict[key] = CombineBytes.ToArray(dataBufferDict[key], 0, dataBufferDict[key].Length, tcpPacket.PayloadData, 0, tcpPacket.PayloadData.Length);
            if (dataBufferDict[key].Length < 4)
            {
               // Debug.WriteLine("receivedBuffer.Length=" + dataBufferDict[key].Length + "< 4 \t -> \t continue");
                return;
            }
            else
            {
                //取msg包头部分
                msgPro = MsgProtocol.FromBytesR(dataBufferDict[key]);
                if (msgPro == null)
                {
                    Debug.WriteLine("数据格式错误!消息为null"+BitConverter.ToString(tcpPacket.PayloadData));
                    dataBufferDict[key] = new byte[] { };
                    return;
                }
                int msgContentLength = msgPro.MessageLength;
                //判断去掉msg包头剩下的长度是否达到可以取包实质内容
                while ((dataBufferDict[key].Length - 4) >= msgContentLength)
                {
                    // Debug.WriteLine("【receivedBuffer去掉包头的长度=" + (receivedBuffer.Length - 4) + "】>=【" + "包实质内容长度=" + msgContentLength + "】");
                    msgPro = null;
                    msgPro = MsgProtocol.FromBytesR(dataBufferDict[key]);
                    if (msgPro == null)
                    {
                        Debug.WriteLine("数据格式错误!消息为null" + BitConverter.ToString(tcpPacket.PayloadData));
                        dataBufferDict[key] = new byte[] { };
                        return;
                    }
                    string filter = "player@ltestplayer@game";
                    if (!msgPro.MessageCommand.Contains("push") && !filter.Contains(msgPro.MessageCommand))
                    {
                        Debug.WriteLine("==============================================================================================================");
                        Debug.WriteLine("接收数据：" + key);
                        Debug.WriteLine("【data】=" + "command:" + msgPro.MessageCommand + " token:" + msgPro.MessageToken);
                        Debug.WriteLine("【json】=" + msgPro.Data);
                    }

                    CommandCacheDict[key2].UpdateData(PacketType.Receive, msgPro.MessageCommand, msgPro.Data);
                    //将得到的json字符串转为对象
                    // var rootObj = JsonHelper.FromJson<dynamic>(msgPro.Data);
                    var rootObj = JsonConvert.DeserializeObject<dynamic>(msgPro.Data);

                    if (SoftContext.CommandList.ContainsKey(key+msgPro.MessageCommand))
                    {
                        SoftContext.CommandList[key + msgPro.MessageCommand] = rootObj;
                    }
                    else
                    {
                        SoftContext.CommandList.Add(key + msgPro.MessageCommand, rootObj);
                    }
                    dataBufferDict[key] = msgPro.ExtraBytes;

                    if (dataBufferDict[key].Length >= 4)
                    {
                        msgPro = MsgProtocol.FromBytesR(dataBufferDict[key]);
                        if (msgPro == null)
                        {
                            Debug.WriteLine("数据格式错误!消息为null" + BitConverter.ToString(tcpPacket.PayloadData));
                            dataBufferDict[key] = new byte[] { };
                            return;
                        }
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

        private void SendData(TcpPacket tcpPacket,string key,string key2)
        {
                //Debug.WriteLine("==============================================================================================================");
                //Debug.WriteLine("发送数据："+key);
                MsgProtocol msgPro = new MsgProtocol();
                dataBufferDict[key] = CombineBytes.ToArray(dataBufferDict[key], 0, dataBufferDict[key].Length, tcpPacket.PayloadData, 0, tcpPacket.PayloadData.Length);
                if (dataBufferDict[key].Length < 4)
                {
                   // Debug.WriteLine("sendBuffer.Length=" + dataBufferDict[key].Length + "< 4 \t -> \t continue");
                    return;
                }
                else
                {
                    //取msg包头部分
                    msgPro = MsgProtocol.FromBytesS(dataBufferDict[key]);
                    if (msgPro == null)
                    {
                        Debug.WriteLine("数据格式错误!消息为null"+BitConverter.ToString(tcpPacket.PayloadData));
                        dataBufferDict[key] = new byte[] { };
                        return;
                    }
                    int msgContentLength = msgPro.MessageLength;
                    //判断去掉msg包头剩下的长度是否达到可以取包实质内容
                    while ((dataBufferDict[key].Length - 4) >= msgContentLength)
                    {
                        // Debug.WriteLine("【sendBuffer去掉包头的长度=" + (sendBuffer.Length - 4) + "】>=【" + "包实质内容长度=" + msgContentLength + "】");
                        msgPro = null;
                        msgPro = MsgProtocol.FromBytesS(dataBufferDict[key]);
                    // Debug.WriteLine("【data】=" + "command:" + msgPro.MessageCommand + " token:" + msgPro.MessageToken);
                    // Debug.WriteLine("【param】=" + msgPro.Data);
                        if (msgPro == null)
                        {
                            Debug.WriteLine("数据格式错误!消息为null" + BitConverter.ToString(tcpPacket.PayloadData));
                            dataBufferDict[key] = new byte[] { };
                            return;
                        }

                    CommandCacheDict[key2].UpdateData(PacketType.Send, msgPro.MessageCommand, msgPro.Data);


                    dataBufferDict[key] = msgPro.ExtraBytes;

                        if (dataBufferDict[key].Length >= 4)
                        {
                            msgPro = MsgProtocol.FromBytesS(dataBufferDict[key]);
                            if (msgPro == null)
                            {
                                Debug.WriteLine("数据格式错误!消息为null" + BitConverter.ToString(tcpPacket.PayloadData));
                                dataBufferDict[key] = new byte[] { };
                                return;
                            }
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

        /// <summary>
        /// 停止抓包
        /// </summary>
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
