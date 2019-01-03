// -----------------------------------------------------------------------
//  <copyright file="MainWindow.xaml.cs" company="柳柳软件">
//      Copyright (c) 2017 66SOFT. All rights reserved.
//  </copyright>
//  <site>http://www.66soft.net</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2017-12-15 12:47</last-date>
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using System.Windows;

using Liuliu.MouseClicker.ViewModels;
using Liuliu.ScriptEngine;

using MahApps.Metro.Controls.Dialogs;

using Microsoft.Practices.ServiceLocation;
using OSharp.Utility.Data;
using System.Diagnostics;
using System.Collections.Generic;
using System;
using System.Linq;
using Liuliu.MouseClicker.Hook;
using SharpPcap;
using System.Text;
using SharpPcap.WinPcap;
using System.Threading;
using Liuliu.MouseClicker.Contexts;
using System.IO;
using PacketDotNet;
using Liuliu.MouseClicker.Models;
using System.Collections.ObjectModel;
using System.IO.Compression;
using PacketDotNet.Ieee80211;
using System.Net;
using Liuliu.MouseClicker.Message;

namespace Liuliu.MouseClicker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            MetroDialogOptions.AffirmativeButtonText = "确定";
            MetroDialogOptions.NegativeButtonText = "取消";
            MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;

            SoftContext.MainWindow = this;
            Loaded += async (o, args) => await MainWindow_Loaded(o, args);


        }

        public ViewModelLocator Locator
        {
            get { return ServiceLocator.Current.GetInstance<ViewModelLocator>(); }
        }

        private async Task MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //初始化大漠对象,注册,新建一个大漠对象
            OperationResult initResult = SoftContext.Initialize();

            if (!initResult.Successed)
            {

                await SoftContext.ShowMessageAsync("初始化失败", initResult.Message);

                SoftContext.RunStatus = SoftRunStatus.StartFail;

                Locator.Main.StatusBar = $"初始化失败：{initResult.Message}";

                return;
            }
            else
            {

                Locator.Main.StatusBar = "准备就绪";
                return;
            }


        }

        private void CmdButton_Initialized(object sender, System.EventArgs e)
        {
            CmdMenuButton.ContextMenu = null;
        }

        private void CmdMenuButton_Click(object sender, RoutedEventArgs e)
        {
            CmdMenu.PlacementTarget = (UIElement)sender;
            CmdMenu.IsOpen = true;
        }
        private void ToolButton_Initialized(object sender, System.EventArgs e)
        {
            ToolMenuButton.ContextMenu = null;
        }

        private void ToolMenuButton_Click(object sender, RoutedEventArgs e)
        {
            ToolMenu.PlacementTarget = (UIElement)sender;
            ToolMenu.IsOpen = true;
        }

        private void ClickSettingsView_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SharpPcap版本：" + SharpPcap.Version.VersionString);
            int i = 0;
            if (File.Exists(@"E:\nox\Nox\bin\nox_adb.exe"))
                i = 0;
            if (File.Exists(@"E:\Nox\bin\nox_adb.exe"))
                i = 1;
            StartCapture(i, "src host 39.96.32.192");
        }

        public class PacketWrapper
        {
            public RawCapture p;

            public int Count { get; private set; }
            public PosixTimeval Timeval { get { return p.Timeval; } }
            public LinkLayers LinkLayerType { get { return p.LinkLayerType; } }
            public int Length { get { return p.Data.Length; } }

            public PacketWrapper(int count, RawCapture p)
            {
                this.Count = count;
                this.p = p;
            }
        }
        private Queue<PacketWrapper> packetStrings;

        private int packetCount;
        private ICaptureStatistics captureStatistics;
        private bool statisticsUiNeedsUpdate = false;
        private TimeSpan LastStatisticsInterval = new TimeSpan(0, 0, 2);
        private DateTime LastStatisticsOutput;
        private Thread backgroundThread;
        private ICaptureDevice device;
        private bool BackgroundThreadStop;
        private PacketArrivalEventHandler arrivalEventHandler;
        private CaptureStoppedEventHandler captureStoppedEventHandler;
        private object QueueLock = new object();
        private Queue<RawCapture> PacketQueue = new Queue<RawCapture>();
        private void StartCapture(int itemIndex, string filter)
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

            // force an initial statistics update
            captureStatistics = device.Statistics;
            UpdateCaptureStatistics();

            device.Filter = filter;

            Debug.WriteLine("-- 正在监听网卡{0} {1},开始抓包！", device.Name, device.Description);
            // start the background capture
            device.StartCapture();
        }
        private void UpdateCaptureStatistics()
        {
            //Debug.WriteLine(string.Format("Received packets: {0}, Dropped packets: {1}, Interface dropped packets: {2}",
            //                                           captureStatistics.ReceivedPackets,
            //                                           captureStatistics.DroppedPackets,
            //                                           captureStatistics.InterfaceDroppedPackets));
        }
        void device_OnCaptureStopped(object sender, CaptureStoppedEventStatus status)
        {
            if (status != CaptureStoppedEventStatus.CompletedWithoutError)
            {
                MessageBox.Show("Error stopping capture", "Error", MessageBoxButton.OK);
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
                        // swap queues, giving the capture callback a new one
                        packet = PacketQueue.Dequeue();
                    }

                    var packetWrapper = new PacketWrapper(packetCount, packet);
                    var time = packet.Timeval.Date;
                    var len = packet.Data.Length;
                    //Debug.WriteLine("BackgroundThread: {0}:{1}:{2},{3} Len={4}",
                    //    time.Hour, time.Minute, time.Second, time.Millisecond, len);
                    var _packet = Packet.ParsePacket(packet.LinkLayerType, packet.Data);

                    var tcpPacket = (TcpPacket)_packet.Extract(typeof(TcpPacket));
                    if (tcpPacket != null)
                    {
                        var ipPacket = (IpPacket)tcpPacket.ParentPacket;
                        IPAddress srcIp = ipPacket.SourceAddress;
                        IPAddress dstIp = ipPacket.DestinationAddress;
                        int srcPort = tcpPacket.SourcePort;
                        int dstPort = tcpPacket.DestinationPort;

                        //Console.WriteLine("{0}:{1}:{2},{3} Len={4} {5}:{6} -> {7}:{8}",
                        //    time.Hour, time.Minute, time.Second, time.Millisecond, len,
                        //    srcIp, srcPort, dstIp, dstPort);

                        Debug.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------");
                        // Debug.WriteLine("数据格式：" + +tcpPacket.PayloadData.Length + "   " + BitConverter.ToString(tcpPacket.PayloadData));
                        #region 注释
                        // Array.Copy(源数据, 源数据开始复制处索引, 接收数据, 接收数据开始处索引, 复制多少个数据);
                        //byte[] dataLenBytes = new byte[4];
                        //byte[] commandBytes = new byte[32];
                        //byte[] unknowBytes = new byte[4];
                        //byte[] dataBytes = null;
                        //try
                        //{
                        //    byte[] tmpData = null;
                        //    tmpData = SimpleCipher.cancelHead(tcpPacket.PayloadData);
                        //    if (tmpData != null)
                        //    {
                        //        dataBytes = new byte[tmpData.Length - 4 - 4 - 32];
                        //        Array.Copy(tmpData, 0, dataLenBytes, 0, 4); //数据长度4字节
                        //        Array.Copy(tmpData, 4, commandBytes, 0, 32); //命令32字节
                        //        Array.Copy(tmpData, 4 + 32, unknowBytes, 0, 4);//编号4字节
                        //        Array.Copy(tmpData, 4 + 32 + 4, dataBytes, 0, tmpData.Length - 4 - 32 - 4); //压缩数据
                        //        if (0x78 == dataBytes[0] && 0x9c == dataBytes[1])
                        //        {
                        //            int dataLen = BitConverter.ToInt32(dataLenBytes.Reverse().ToArray(), 0);
                        //            string command = Encoding.UTF8.GetString(commandBytes).Replace("\0", "");
                        //            int unknow = BitConverter.ToInt32(unknowBytes.Reverse().ToArray(), 0);
                        //            Debug.WriteLine("数据长度:" + dataLen + ",命令:" + command + ",编号:" + unknow);
                        //            if(dataLen==(tmpData.Length-4))
                        //            {
                        //                string jsonStr = Encoding.UTF8.GetString(Zip.DeCompress(dataBytes));
                        //                Debug.WriteLine(jsonStr);
                        //                if (command==CommandList.QuenchingAndGetEquips)
                        //                {
                        //                   var obj=JsonHelper.FromJson<RootObject>(jsonStr);

                        //                }
                        //        }
                        //            else
                        //            {
                        //              Debug.WriteLine("该包不是完整的包！:" + tcpPacket.PayloadData.Length + "   " + BitConverter.ToString(tcpPacket.PayloadData));
                        //              Debug.WriteLine(Encoding.UTF8.GetString(Zip.DeCompress(dataBytes)));
                        //            }





                        //        }
                        //        else
                        //        {
                        //            Debug.WriteLine("数据错误:" +tcpPacket.PayloadData.Length + "   " + BitConverter.ToString(tcpPacket.PayloadData));
                        //        }
                        //    }
                        //    else
                        //    {
                        //        Debug.WriteLine("未知数据格式："+tcpPacket.PayloadData.Length + "   " + BitConverter.ToString(tcpPacket.PayloadData));
                        //    }

                        //}
                        //catch (Exception ex)
                        //{
                        //    Debug.WriteLine(ex.Message);
                        //    Debug.WriteLine("发生异常：" + tcpPacket.PayloadData.Length +"   "+BitConverter.ToString(tcpPacket.PayloadData));
                        //}
                        #endregion
                        MsgProtocol msgPro = new MsgProtocol();

                        byte[] buffer = new byte[4096];//定义一个大小为64的缓冲区
                                                       //byte[] receivedBytes = new byte[] { };
                        byte[] receivedBuffer = new byte[] { };//大小可变的缓存器
                        receivedBuffer = CombineBytes.ToArray(receivedBuffer, 0, receivedBuffer.Length, tcpPacket.PayloadData, 0, tcpPacket.PayloadData.Length);
                        if (receivedBuffer.Length < 4)
                        {
                            Debug.WriteLine("receivedBuffer.Length=" + receivedBuffer.Length + "< 6 \t -> \t continue");
                            continue;
                        }
                        else
                        {
                            //取msgXY包头部分
                            msgPro = MsgProtocol.FromBytes(receivedBuffer);
                            int msgContentLength = msgPro.MessageLength;
                            //判断去掉msg包头剩下的长度是否达到可以取包实质内容
                            while ((receivedBuffer.Length - 4) >= msgContentLength)
                            {
                                Debug.WriteLine("【receivedBuffer去掉包头的长度=" + (receivedBuffer.Length - 4) + "】>=【" + "包实质内容长度=" + msgContentLength + "】");
                                msgPro = null;
                                msgPro = MsgProtocol.FromBytes(receivedBuffer);
                                Debug.WriteLine("\n【拆包】=" + Encoding.UTF8.GetString(Zip.DeCompress(msgPro.JsonData)) + "\n");

                                receivedBuffer = msgPro.ExtraBytes;
                                Console.WriteLine("【剩余的receivedBuffer】receivedBuffer.Length=" + receivedBuffer.Length);

                                if (receivedBuffer.Length >= 4)
                                {
                                    msgPro = MsgProtocol.FromBytes(receivedBuffer);

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

            }
            if (statisticsUiNeedsUpdate)
            {
                UpdateCaptureStatistics();
                statisticsUiNeedsUpdate = false;
            }
        }



        void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {   //输出包统计信息
            // print out periodic statistics about this device
            var Now = DateTime.Now; // cache 'DateTime.Now' for minor reduction in cpu overhead
            var interval = Now - LastStatisticsOutput;
            if (interval > LastStatisticsInterval)
            {
                // Debug.WriteLine("device_OnPacketArrival: " + e.Device.Statistics);
                captureStatistics = e.Device.Statistics;
                statisticsUiNeedsUpdate = true;
                LastStatisticsOutput = Now;
            }

            // lock QueueLock to prevent multiple threads accessing PacketQueue at
            // the same time
            lock (QueueLock)
            {
                PacketQueue.Enqueue(e.Packet);
            }
        }
        //private static void device_OnPacketArrival(object sender, CaptureEventArgs e)
        //{
        //    var time = e.Packet.Timeval.Date;
        //    var len = e.Packet.Data.Length;
        //   // Debug.WriteLine("{0}:{1}:{2},{3} Len={4}", time.Hour, time.Minute, time.Second, time.Millisecond, len);
        //   if(len>54)
        //    {
        //        var packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
        //        var tcpPacket = packet.Extract(typeof(TcpPacket));
        //        if(tcpPacket!=null)
        //        {
        //            var ipPacket = (IpPacket)tcpPacket.ParentPacket;
        //            IPAddress srcIp = ipPacket.SourceAddress;
        //            IPAddress dstIp = ipPacket.DestinationAddress;
        //            if(srcIp.ToString()== "39.96.32.192")
        //            {
        //                Debug.WriteLine("--------------------------------------------------------------------");
        //                Debug.WriteLine("数据格式：" + BitConverter.ToString(tcpPacket.PayloadData));
        //                // Array.Copy(源数据, 源数据开始复制处索引, 接收数据, 接收数据开始处索引, 复制多少个数据);
        //                byte[] dataLenBytes = new byte[4];
        //                byte[] commandBytes = new byte[32];
        //                byte[] unknowBytes = new byte[4];
        //                byte[] dataBytes = null;
        //                try
        //                {
        //                    byte[] tmpData=null;
        //                    tmpData = SimpleCipher.cancelHead(tcpPacket.PayloadData);
        //                    if(tmpData!=null)
        //                    {
        //                        dataBytes = new byte[tmpData.Length - 4 - 4 - 32];
        //                        Array.Copy(tmpData, 0, dataLenBytes, 0, 4); //数据长度4字节
        //                        Array.Copy(tmpData, 4, commandBytes, 0, 32); //命令32字节
        //                        Array.Copy(tmpData, 4 + 32, unknowBytes, 0, 4);//编号4字节
        //                        Array.Copy(tmpData, 4 + 32 + 4, dataBytes, 0, tmpData.Length - 4 - 32 - 4); //压缩数据
        //                        if (0x78 == dataBytes[0] && 0x9c == dataBytes[1])
        //                        {
        //                            int dataLen = BitConverter.ToInt32(dataLenBytes.Reverse().ToArray(), 0);
        //                            string command = Encoding.UTF8.GetString(commandBytes);
        //                            int unknow = BitConverter.ToInt32(unknowBytes.Reverse().ToArray(), 0);
        //                            Debug.WriteLine("数据长度:" + dataLen + ",命令:" + command.Replace("\0", "") + ",编号:" + unknow);
        //                            Debug.WriteLine(Encoding.UTF8.GetString(Zip.DeCompress(dataBytes)));
        //                        }
        //                        else
        //                        {
        //                            Debug.WriteLine("数据错误:" + BitConverter.ToString(tcpPacket.PayloadData));
        //                        }
        //                    }
        //                    else
        //                    {
        //                        Debug.WriteLine("未知数据格式："+BitConverter.ToString(tcpPacket.PayloadData));
        //                    }

        //                }
        //                catch (Exception ex)
        //                {
        //                    Debug.WriteLine(ex.Message);
        //                    Debug.WriteLine("发生异常：" + BitConverter.ToString(tcpPacket.PayloadData));
        //                }
        //                Debug.WriteLine("--------------------------------------------------------------------");
        //            }
        //        }
        //    }

        //}


        /// <summary>
        /// 是否存在某字节字符串
        /// </summary>
        /// <param name="byteshuzu"></param>
        /// <param name="bytestr"></param>
        /// <returns></returns>
        private bool IsHasBytes(byte[] byteshuzu, string bytestr)
        {
            return BitConverter.ToString(byteshuzu).IndexOf(bytestr) > 0;
        }

        private void StopCaptureButton_Click(object sender, RoutedEventArgs e)
        {
            Shutdown();
        }

        private void Shutdown()
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