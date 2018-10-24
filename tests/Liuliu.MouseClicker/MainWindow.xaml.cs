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

            SocketInterFace.logEvent += new SocketInterFace.LogArgsHander(MainSend);
            if (!EasyHook.RemoteHooking.IsAdministrator)
                MessageBox.Show("请用管理员方式启动");
        }
        public void MainSend(SocketInterFace.BufferStruct buff)
        {
            Debug.WriteLine(string.Format("长度:{0} 类型:{2}\r\n 内容:{1}", buff.BufferSize, byteToHexStr(buff.Buffer, buff.BufferSize), buff.ObjectType));
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
        public static string byteToHexStr(byte[] bytes, int byteLen)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < byteLen; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
        string ChannelName = null;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EasyHook.Config.Register(".net远程注入组建", "socketHook.exe", "sockethookinject.dll");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            int id = Process.GetProcessesByName("SupARC").First().Id;
            if (id != 0)
            {
                EasyHook.RemoteHooking.IpcCreateServer<SocketInterFace>(ref ChannelName, System.Runtime.Remoting.WellKnownObjectMode.SingleCall);
                EasyHook.RemoteHooking.Inject(id, "sockethookinject.dll", "sockethookinject.dll", ChannelName);
            }
            else
            {
                MessageBox.Show("ARC没有启动");
            }
        }
    }
}