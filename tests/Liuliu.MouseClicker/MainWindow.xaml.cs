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
using Liuliu.MouseClicker.PacketSend;
using sy07073.mobile.game.sdk.unit;
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



        public void LoginGameTest()
        {
            try
            {
                Login target = new Login(); // TODO: 初始化为适当的值
                target.Uname = "用户名";
                target.Passwd = "密码";
                // ExcuteState expected = null; // TODO: 初始化为适当的值
                ExcuteState actual;
                actual = target.LoginGame();
                if (actual.State == IdentityCode.Fail)
                    return;

                bool bSuccess = target.getUserkeyFromCookie();
                bSuccess = target.getPkeyFromCookie();
                RoleSel role = new RoleSel(target.Client);
                role.TasktxtPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "自动任务列表.txt";
                role.StrServerName = target.StrServerName;
                actual = role.getPlayerList();
                if (actual.State == IdentityCode.Fail)
                    return;

                if (role.Rolelist.Count > 0)
                {
                    webRole roler = role.Rolelist[0];
                    actual = role.getPlayerInfo(roler);
                    if (actual.State == IdentityCode.Fail)
                        return;
                }


                bool bret = role.getServerIP();
                if (!bret)
                    return;


                Dictionary<string, string> lst = new Dictionary<string, string>(); // TODO: 初始化为适当的值
                lst.Add("userkey", target.Userkey);
                Command cmd = new Command("login_user", lst);
                byte[] sendarr = cmd.outputarr;

                RoleInfoStoreClient client = new RoleInfoStoreClient(role.ServerAddr, role.ServerPort);
                client.Send(sendarr);
                client.SendDone.WaitOne();

                client.Receive();
                client.ReceiveDone.WaitOne();

                // 

                int i = 0;
                while (i++ < 5)
                {
                    Thread.Sleep(1000);
                }

                // 开启线程 发送心跳报文
                CommandList cmdlst = new CommandList(role.Roledetail.pkey2, client);
                Thread heatThread = new Thread(cmdlst.HeatBeatThread);
                heatThread.IsBackground = true;
                heatThread.Start();

                // CommandList.SendGetBuildingInfo(client, 1);

                // 获取主城信息
                CommandList.GetMainCityInfo(client);

                // Thread.Sleep(100);
                Command cmd4 = new Command(CommandList.GENERAL_GET_GENERALSIMPLEINFO2, lst);
                client.Send(cmd4.outputarr);
                client.SendDone.WaitOne();

                i = 0;
                while (i++ < 5)
                {
                    Thread.Sleep(1000);
                }
                // 获取主城信息
                client.SetJson2AreaLst();

                i = 0;
                // 获取当前任务，执行
                PacketSend.Task curTask = role.CurTask;
                TaskExecute tasker = new TaskExecute(client);

                while (i++ < 60)
                {
                    Thread.Sleep(1000);
                    bret = tasker.ExecuteTask(ref role);
                    if (!bret)
                    {
                        Thread.Sleep(1000 * 5);
                        break;
                    }
                }

                client.PrintInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ";" + ex.StackTrace);
            }

        }
        private async System.Threading.Tasks.Task MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

           var temp= Des.decodeValue("ZpqEsAkjVvcNjnvmuzMEw9M8pdaVy1nkZ2Ns0IzVYfqtKJYCcNdKn0GwY8w4pwNJUmHSNKsM/PXJgeUlCsmPn/PO34OYMYFd8HTAX3mCS3mSZ/OwREI7j31/dhs7mAu4ZoQeKXuBOWlme8moRj4Z50VXwhHYeMhn");
            Debug.WriteLine(Encoding.UTF8.GetString(Zip.DeCompress(new byte[] {0x78,0x9c,0x1d,0xc9,0x39,0x12,0x80,0x20,0x0c,0x00,0xc0,0xbf,0xa4,0xb6,0x30,0x1c,0xe1,0xe8,0x8c,0x50,0xf8,0x8c,0x8c,0x50,0xd8,0x68,0x01,0x1d,0xc3,0xdf,0x75,0x6c,0x77,0x07,0xc8,0xd9,0xaf,0xe7,0x86,0x38,0xa0,0x75,0xe9,0x15,0x22,0x2e,0x50,0xa4,0xcb,0x2f,0xb5,0xb5,0x2f,0x8f,0x02,0x11,0x92,0x36,0xe8,0x39,0xe5,0xb0,0xa2,0x66,0x45,0x9b,0xf2,0xec,0x42,0x36,0xb4,0x33,0x51,0x62,0xb4,0xe8,0xbc,0xe5,0x1d,0xe6,0x9c,0x2f,0x42,0x80,0x18,0x05 })));
          
            //LoginGameTest();
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
                Debug.WriteLine("SharpPcap版本：" + SharpPcap.Version.VersionString);
                int i = 0;
                if (File.Exists(@"E:\nox\Nox\bin\nox_adb.exe"))
                    i = 0;
                if (File.Exists(@"E:\Nox\bin\nox_adb.exe"))
                    i = 1;
                CaptureService.GetInstance().StartCapture(i, "host " + SoftContext.ServerIp);

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
           CaptureService.GetInstance().StartCapture(i, "host "+SoftContext.ServerIp);
        }

        private void StopCaptureButton_Click(object sender, RoutedEventArgs e)
        {
       

            CaptureService.GetInstance().Shutdown();
        }
    }
}