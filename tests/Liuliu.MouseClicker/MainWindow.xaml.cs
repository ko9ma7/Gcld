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
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            Task task = new Task(() =>
            {
                Debug.WriteLine("SharpPcap版本：" + SharpPcap.Version.VersionString);
                // Retrieve the device list
                var devices = CaptureDeviceList.Instance;

                // If no devices were found print an error
                if (devices.Count < 1)
                {
                    Debug.WriteLine("出现错误：电脑未检测到网卡！");
                    return;
                }

                Debug.WriteLine("该电脑有以下网卡:");
                Debug.WriteLine("----------------------------------------------------");
                int i = 0;
                foreach (var dev in devices)
                {
                    Debug.WriteLine("{0}) {1} {2}", i, dev.Name, dev.Description);
                    i++;
                }
                Debug.WriteLine("-- 选择一个网卡抓包: ");
                if (File.Exists(@"E:\nox\Nox\bin\nox_adb.exe"))
                    i = 0;
                if (File.Exists(@"E:\Nox\bin\nox_adb.exe"))
                    i = 1;
                var device = devices[i];

                // Register our handler function to the 'packet arrival' event
                device.OnPacketArrival +=
                    new PacketArrivalEventHandler(device_OnPacketArrival);

                // Open the device for capturing
                int readTimeoutMilliseconds = 1000;

                if (device is WinPcapDevice)
                {
                    var winPcap = device as WinPcapDevice;
                    winPcap.Open(OpenFlags.DataTransferUdp | OpenFlags.NoCaptureLocal, readTimeoutMilliseconds);
                }
                else
                {
                    throw new InvalidOperationException("未知的设备类型： " + device.GetType().ToString());
                }


                Debug.WriteLine("-- 正在监听网卡{0} {1},开始抓包！", device.Name, device.Description);

                // tcpdump filter to capture only TCP/IP packets
                string filter = "host 39.96.32.192";
                device.Filter = filter;
                device.StartCapture();

              //  while (!token.IsCancellationRequested)
               // {
                    Thread.Sleep(250000);
              //  }
                device.StopCapture();

                Debug.WriteLine("--捕获结束.");
                // Print out the device statistics
                Debug.WriteLine(device.Statistics.ToString());

                // Close the pcap device
                device.Close();
            },token);
           
            task.Start();
            task.Wait();
            tokenSource.Cancel();
        }


        private static void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            var time = e.Packet.Timeval.Date;
            var len = e.Packet.Data.Length;
           // Debug.WriteLine("{0}:{1}:{2},{3} Len={4}", time.Hour, time.Minute, time.Second, time.Millisecond, len);
           if(len>54)
            {
                var packet = Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
                var tcpPacket = packet.Extract(typeof(TcpPacket));
                if(tcpPacket!=null)
                {
                    var ipPacket = (IpPacket)tcpPacket.ParentPacket;
                    IPAddress srcIp = ipPacket.SourceAddress;
                    IPAddress dstIp = ipPacket.DestinationAddress;
                    if(srcIp.ToString()== "39.96.32.192")
                    {
                        Debug.WriteLine("--------------------------------------------------------------------");
                        Debug.WriteLine("数据格式：" + BitConverter.ToString(tcpPacket.PayloadData));
                        // Array.Copy(源数据, 源数据开始复制处索引, 接收数据, 接收数据开始处索引, 复制多少个数据);
                        byte[] dataLenBytes = new byte[4];
                        byte[] commandBytes = new byte[32];
                        byte[] unknowBytes = new byte[4];
                        byte[] dataBytes = null;
                        try
                        {
                            byte[] tmpData=null;
                            tmpData = SimpleCipher.cancelHead(tcpPacket.PayloadData);
                            if(tmpData!=null)
                            {
                                dataBytes = new byte[tmpData.Length - 4 - 4 - 32];
                                Array.Copy(tmpData, 0, dataLenBytes, 0, 4); //数据长度4字节
                                Array.Copy(tmpData, 4, commandBytes, 0, 32); //命令32字节
                                Array.Copy(tmpData, 4 + 32, unknowBytes, 0, 4);//编号4字节
                                Array.Copy(tmpData, 4 + 32 + 4, dataBytes, 0, tmpData.Length - 4 - 32 - 4); //压缩数据
                                if (0x78 == dataBytes[0] && 0x9c == dataBytes[1])
                                {
                                    int dataLen = BitConverter.ToInt32(dataLenBytes.Reverse().ToArray(), 0);
                                    string command = Encoding.UTF8.GetString(commandBytes);
                                    int unknow = BitConverter.ToInt32(unknowBytes.Reverse().ToArray(), 0);
                                    Debug.WriteLine("数据长度:" + dataLen + ",命令:" + command.Replace("\0", "") + ",编号:" + unknow);
                                    Debug.WriteLine(Encoding.UTF8.GetString(Zip.DeCompress(dataBytes)));
                                }
                                else
                                {
                                    Debug.WriteLine("数据错误:" + BitConverter.ToString(tcpPacket.PayloadData));
                                }
                            }
                            else
                            {
                                Debug.WriteLine("未知数据格式："+BitConverter.ToString(tcpPacket.PayloadData));
                            }
                           
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                            Debug.WriteLine("发生异常：" + BitConverter.ToString(tcpPacket.PayloadData));
                        }
                        Debug.WriteLine("--------------------------------------------------------------------");
                    }
                }
            }
      
        }


        /// <summary>
        /// 是否存在某字节字符串
        /// </summary>
        /// <param name="byteshuzu"></param>
        /// <param name="bytestr"></param>
        /// <returns></returns>
        private bool IsHasBytes(byte[] byteshuzu,string bytestr)
        {
            return BitConverter.ToString(byteshuzu).IndexOf(bytestr)>0;
        }
    }
}