using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

using GalaSoft.MvvmLight.Messaging;
using Liuliu.MouseClicker.ViewModels;
using Liuliu.ScriptEngine;
using Microsoft.Win32;
using Liuliu.ScriptEngine.Damo;
using System.Diagnostics;

namespace Liuliu.MouseClicker.Flyouts
{
    /// <summary>
    /// SettingsFlyout.xaml 的交互逻辑
    /// </summary>
    public partial class SettingsFlyout
    {
        public SettingsFlyout()
        {
            InitializeComponent();
            RegisterMessengers();
            Debug.WriteLine("1111233");
            IsOpenChanged += async (sender, e) => await SettingsFlyout_IsOpenChanged(sender, e);
        }

        private void RegisterMessengers()
        {
            Messenger.Default.Register<string>(this, "SettingsFlyout",
                async msg =>
                {
                    Debug.WriteLine("2232423");
                    Debug.WriteLine(msg);
                    switch (msg)
                    {
                        case "OpenSettingsFlyout":
                            OpenSettingsFlyout();
                            break;
                        case "DmFileBrowse":
                            DmFileBrowse();
                            break;
                    }
                });

        }

        private void OpenSettingsFlyout()
        {
            if (!IsOpen)
            {
                IsOpen = true;
            }
        }

        private async Task SettingsFlyout_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            SettingsViewModel model = SoftContext.Locator.Settings;
            if (IsOpen)
            {
                model.InitFromLocal();
                if (SoftContext.DmSystem == null)
                {
                    await ResolveDmPlugin();
                }
                return;
            }
            model.SaveToLocal();
            SoftContext.Locator.Main.StatusBar = "设置信息保存成功";
        }

        private static void DmFileBrowse()
        {
            SettingsViewModel model = SoftContext.Locator.Settings;
            OpenFileDialog dialog = new OpenFileDialog() { Filter = "大漠插件|dm*.dll|dll文件|*.dll", FileName = model.DmFile };
            dialog.FileOk += async (sender, args) =>
            {
                model.DmFile = dialog.FileName;
                await ResolveDmPlugin();
            };
            dialog.ShowDialog();
        }

        private static async Task ResolveDmPlugin()
        {
            SettingsViewModel model = SoftContext.Locator.Settings;
            if (!File.Exists(model.DmFile))
            {
                await SoftContext.ShowMessageAsync("错误", $"指定大漠路径“{model.DmFile}”的文件不存在");
                return;
            }
            try
            {
                DmPlugin dm = new DmPlugin(model.DmFile);
                Version ver = new Version(dm.Ver());
                model.DmVersion = ver.ToString();
                model.DmVersionShow = true;
                model.DmRegCodeShow = ver > new Version("3.1233");
                SoftContext.DmSystem = new DmSystem(dm);
            }
            catch (Exception ex)
            {
                await SoftContext.MainWindow.Dispatcher.Invoke(async () =>
                {
                    await SoftContext.ShowMessageAsync("错误", $"大漠初始化错误：{ex.Message}");
                });
                model.DmFile = null;
            }
        }
    }
}
