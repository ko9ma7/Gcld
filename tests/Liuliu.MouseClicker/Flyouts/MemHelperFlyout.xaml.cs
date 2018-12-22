using GalaSoft.MvvmLight.Messaging;
using Liuliu.MouseClicker.Contexts;
using Liuliu.MouseClicker.Models;
using Liuliu.MouseClicker.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// AccountFlyout.xaml 的交互逻辑
    /// </summary>
    public partial class MemHelperFlyout
    {
        public MemHelperFlyout()
        {
            InitializeComponent();
            RegisterMessengers();
            IsOpenChanged += async (sender, e) => await MemHelperFlyout_IsOpenChanged(sender, e);
        }
        private void RegisterMessengers()
        {
            Messenger.Default.Register<string>(this, Notifications.MemHelperFlyout,
                (msg) =>
               {
                   switch(msg)
                   {
                       case "OpenMemHelperFlyout":
                           OpenMemHelperFlyout();
                           break;
                   }
               });
        }

        private void OpenMemHelperFlyout()
        {
            if (!IsOpen)
            {
                IsOpen = true;
            }
        }

        private async Task MemHelperFlyout_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            //AccountViewModel model = SoftContext.Locator.M;
            if (IsOpen)
            {
                //model.InitFromLocal();
              
                return;
            }
            //model.SaveToLocal();
            SoftContext.Locator.Main.StatusBar = "程序列表更新成功";
        }

        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
