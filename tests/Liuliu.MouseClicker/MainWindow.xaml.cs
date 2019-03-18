// -----------------------------------------------------------------------
//  <copyright file="MainWindow.xaml.cs" company="柳柳软件">
//      Copyright (c) 2017 66SOFT. All rights reserved.
//  </copyright>
//  <site>http://www.66soft.net</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2017-12-15 12:47</last-date>
// -----------------------------------------------------------------------

using Liuliu.MouseClicker.Contexts;
using Liuliu.MouseClicker.Message;
using Liuliu.MouseClicker.Models;
using Liuliu.MouseClicker.PacketSend;
using Liuliu.MouseClicker.PlatformLogin;
using Liuliu.MouseClicker.ViewModels;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.ServiceLocation;
using OSharp.Utility.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

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
            try
            {
                GameLogin game = new GameLogin("huang77", "huang77");
                game.Login(PlatformLogin.Platform.楚游_070703sy);
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
           
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
                    i = 0;
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
            GameDataContext context = new GameDataContext();
            var list = context.PlayerInfos.ToList();
            int count = 0;
            foreach (var item in list)
            {
                count = count + int.Parse(item.UGold) + int.Parse(item.Gold);
            }
            Console.WriteLine(count);
            Console.ReadLine();

            // CaptureService.GetInstance().Shutdown();
        }
    }
}