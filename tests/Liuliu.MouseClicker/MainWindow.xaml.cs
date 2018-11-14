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

        private void Button_Initialized(object sender, System.EventArgs e)
        {
            CmdMenuButton.ContextMenu = null;
        }

        private void CmdMenuButton_Click(object sender, RoutedEventArgs e)
        {
            CmdMenu.PlacementTarget = (UIElement)sender;
            CmdMenu.IsOpen = true;
        }

        private void ClickSettingsView_Loaded(object sender, RoutedEventArgs e)
        {

        }
     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = "C3 69 8F 66 63 C1 A1 D1";
            byte[] temp = Encoding.Unicode.GetBytes("强防");
            string str = Encoding.Unicode.GetString(new byte[] { 0x3A, 0x5F, 0x32,0x96 });
            string str2 = Encoding.Unicode.GetString(new byte[] { 0xC3, 0x69 });
            string str3 = Encoding.Unicode.GetString(new byte[] { 0x69, 0x8F });
            string str4 = Encoding.Unicode.GetString(new byte[] { 0x8F, 0x66 });
            string str5 = Encoding.Unicode.GetString(new byte[] { 0x66, 0x63 });
            string str6 = Encoding.Unicode.GetString(new byte[] { 0x63, 0xC1 });
            string str7 = Encoding.Unicode.GetString(new byte[] { 0xC1, 0xA1 });
            Debug.WriteLine(temp);
            return;
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";//设置启动的应用程序
            p.StartInfo.UseShellExecute = false;//禁止使用操作系统外壳程序启动进程
            p.StartInfo.RedirectStandardInput = true;//应用程序的输入从流中读取
            p.StartInfo.RedirectStandardOutput = true;//应用程序的输出写入流中
            p.StartInfo.RedirectStandardError = true;//将错误信息写入流
            p.StartInfo.CreateNoWindow = true;//是否在新窗口中启动进程
            p.Start();
            //p.StandardInput.WriteLine(@"netstat -a -n>c:\port.txt");//将字符串写入文本流
           
            try
            {
                p.StandardInput.WriteLine(@"netstat -aon|findstr ""42.62.119.245"">" + AppDomain.CurrentDomain.BaseDirectory + @"\port.txt");
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
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
                string filter = "host 42.62.119.245";
                device.Filter = filter;
                device.StartCapture();

                while (!token.IsCancellationRequested)
                {
                    Thread.Sleep(5000);
                }
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
            Debug.WriteLine("{0}:{1}:{2},{3} Len={4}", time.Hour, time.Minute, time.Second, time.Millisecond, len);
            Debug.WriteLine(BitConverter.ToString(e.Packet.Data));
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