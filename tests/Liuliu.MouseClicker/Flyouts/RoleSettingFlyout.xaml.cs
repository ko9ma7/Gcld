using GalaSoft.MvvmLight.Messaging;
using Liuliu.MouseClicker.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Liuliu.MouseClicker.Flyouts
{
    /// <summary>
    /// RoleSettingFlyout.xaml 的交互逻辑
    /// </summary>
    public partial class RoleSettingFlyout
    {
        public RoleSettingFlyout()
        {
            InitializeComponent();
            RegisterMessengers();
            IsOpenChanged += async (sender, e) => await RoleSettingFlyout_IsOpenChanged(sender, e);
        }

        private void RegisterMessengers()
        {
            Messenger.Default.Register<string>(this, "RoleSettingFlyout",
               async msg =>
                {
                    Debug.WriteLine(msg);
                    switch (msg)
                    {
                        case "OpenRoleSettingFlyout":
                            OpenRoleSettingFlyout();
                            break;
                    }
                });

        }

        private void OpenRoleSettingFlyout()
        {
            if (!IsOpen)
            {
                IsOpen = true;
            }
        }

        private async Task RoleSettingFlyout_IsOpenChanged(object sender, RoutedEventArgs e)
        {

            RoleSettingViewModel model = SoftContext.Locator.RoleSetting;
            if (IsOpen)
            {
                return;
            }
           
            SoftContext.Locator.Main.StatusBar = "设置信息保存成功";
        }

    }
}
