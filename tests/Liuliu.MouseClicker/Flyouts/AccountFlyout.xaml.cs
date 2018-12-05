using GalaSoft.MvvmLight.Messaging;
using Liuliu.MouseClicker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class AccountFlyout
    {
        public AccountFlyout()
        {
            InitializeComponent();
            RegisterMessengers();
           
        }
        Role _role = null;
        private void RegisterMessengers()
        {
            
            Messenger.Default.Register<Role>(this, "OpenAccountFlyout",
                (role) =>
               {
                   _role = role;
                   OpenAccountFlyout();     
               });
            Messenger.Default.Register<Role>(this, "OpenAllAccountFlyout",
             (role) =>
             {
                 _role = role;
                 OpenAllAccountFlyout();
             });
        }

        private void OpenAllAccountFlyout()
        {
            if (!IsOpen)
            {
                SoftContext.Locator.Accounts.AccountList = new ObservableCollection<Account>(SoftContext.AccountList);
                IsOpen = true;
            }
        }

        private void OpenAccountFlyout()
        {
            if (!IsOpen)
            {
                SoftContext.Locator.Accounts.AccountList=new ObservableCollection<Account>(SoftContext.AccountList.Where(x => x.IsFinished == false));
                IsOpen = true;
            }
        }

        private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = e.Row.GetIndex() + 1;
        }
    }
}
