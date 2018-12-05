using GalaSoft.MvvmLight.Command;
using Liuliu.MouseClicker.Models;
using Liuliu.MouseClicker.Mvvm;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using System;
using System.Collections.Generic;

namespace Liuliu.MouseClicker.ViewModels
{
    public class AccountViewModel : ViewModelExBase
    {
        public AccountViewModel()
        {
            _mylist = new ObservableCollection<Account>(SoftContext.AccountList.Where(x=>x.IsFinished==false));
        }

        ObservableCollection<Account> _mylist;
        public ObservableCollection<Account> AccountList
        {
            get { return _mylist; }
            set { SetProperty(ref _mylist, value, () => AccountList); }
        }


        public ICommand StartCommand
        {
            get
            {
                return new RelayCommand<Account>((account) =>
                {
                    if (account != null)
                        Debug.WriteLine(account.UserName);
                    
                });
            }
        }

        public ICommand StopCommand
        {
            get
            {
                return new RelayCommand<Account>((account) =>
                {
                    if (account != null)
                        Debug.WriteLine(account.UserName);
                });
            }
        }
    }
}
