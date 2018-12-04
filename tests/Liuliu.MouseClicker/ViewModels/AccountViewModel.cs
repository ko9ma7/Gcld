using GalaSoft.MvvmLight.Command;
using Liuliu.MouseClicker.Models;
using Liuliu.MouseClicker.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Liuliu.MouseClicker.ViewModels
{
    public class AccountViewModel : ViewModelExBase
    {
        public AccountViewModel()
        {
            _mylist = new ObservableCollection<Account>()
            {
                new Account() {UserName="rhjv99",Password="rhjv99",Platform=Platform.飞流,IsFinished=false,IsWorking=false },
                new Account() {UserName="rhjv88",Password="rhjv88",Platform=Platform.飞流,IsFinished=false,IsWorking=false },
                new Account() {UserName="rhjv77",Password="rhjv77",Platform=Platform.飞流,IsFinished=false,IsWorking=false },
                new Account() {UserName="rhjv66",Password="rhjv66",Platform=Platform.飞流,IsFinished=false,IsWorking=false },
                new Account() {UserName="rhjv55",Password="rhjv55",Platform=Platform.飞流,IsFinished=false,IsWorking=false },
                new Account() {UserName="rhjv44",Password="rhjv44",Platform=Platform.飞流,IsFinished=false,IsWorking=false },
                new Account() {UserName="daipf99",Password="daipf99",Platform=Platform.楚游,IsFinished=false,IsWorking=false },
                new Account() {UserName="daipf88",Password="daipf88",Platform=Platform.楚游,IsFinished=false,IsWorking=false },
                new Account() {UserName="daipf77",Password="daipf77",Platform=Platform.楚游,IsFinished=false,IsWorking=false },
                new Account() {UserName="daipf66",Password="daipf66",Platform=Platform.楚游,IsFinished=false,IsWorking=false },
                new Account() {UserName="daipf55",Password="daipf55",Platform=Platform.楚游,IsFinished=false,IsWorking=false },
                new Account() {UserName="daipf44",Password="daipf44",Platform=Platform.楚游,IsFinished=false,IsWorking=false },
                new Account() {UserName="daipf33",Password="daipf33",Platform=Platform.楚游,IsFinished=false,IsWorking=false },
                new Account() {UserName="daipf22",Password="daipf22",Platform=Platform.楚游,IsFinished=false,IsWorking=false },
                new Account() {UserName="daipf11",Password="daipf11",Platform=Platform.楚游,IsFinished=false,IsWorking=false },
                new Account() {UserName="daipf00",Password="daipf00",Platform=Platform.楚游,IsFinished=false,IsWorking=false },
                new Account() {UserName="huang99",Password="huang99",Platform=Platform.楚游,IsFinished=false,IsWorking=false },
                new Account() {UserName="huang88",Password="huang88",Platform=Platform.楚游,IsFinished=false,IsWorking=false },
                new Account() {UserName="huang77",Password="huang77",Platform=Platform.楚游,IsFinished=false,IsWorking=false },

            };
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
