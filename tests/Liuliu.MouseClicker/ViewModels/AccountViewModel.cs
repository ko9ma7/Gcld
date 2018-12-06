using GalaSoft.MvvmLight.Command;
using Liuliu.MouseClicker.Models;
using Liuliu.MouseClicker.Mvvm;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using Liuliu.ScriptEngine.Models;
using Liuliu.ScriptEngine.Tasks;
using Liuliu.MouseClicker.Contexts;
using System.IO;
using Liuliu.ScriptEngine;
using Liuliu.ScriptEngine.Damo;
using Liuliu.MouseClicker.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;

namespace Liuliu.MouseClicker.ViewModels
{
    public class AccountViewModel : ViewModelExBase
    {
        public AccountViewModel()
        {
            Messenger.Default.Register<string>(this, Notifications.AccountViewModel,
             (msg) =>
             {
                 switch (msg)
                 {
                     case "OpenAccountFlyout":
                         AccountList = new ObservableCollection<Account>(SoftContext.AccountList.Where(x => x.IsFinished == false));
                         break;
                     case "OpenAllAccountFlyout":
                         AccountList = new ObservableCollection<Account>(SoftContext.AccountList);
                         break;
                 }
             });

        }

        ObservableCollection<Account> _mylist;
        public ObservableCollection<Account> AccountList
        {
            get { return _mylist; }
            set { SetProperty(ref _mylist, value, () => AccountList); }
        }

        [JsonIgnore]
        public ICommand StartCommand
        {
            get
            {
                return new RelayCommand<Account>((account) =>
                {
                    Messenger.Default.Send(new SendData<Account>() { Message = "Login", Data = account }, Notifications.MainCommandViewModel);
                });
            }
        }
        [JsonIgnore]
        public ICommand StopCommand
        {
            get
            {
                return new RelayCommand<Account>((account) =>
                {
                    Messenger.Default.Send(new SendData<Account>() { Message = "Stop", Data = account }, Notifications.MainCommandViewModel);
                });
            }
        }
        public string TodayTime { get; set; }
        /// <summary>
        /// 从本地数据初始化
        /// </summary>
        public void InitFromLocal()
        {
            var model = LocalDataHandler.GetData<AccountViewModel>("data.db", "accounts");
            if (model != null)
            {
                if (model.TodayTime != DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    AccountList = new ObservableCollection<Account>(SoftContext.AccountList);
                    TodayTime = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    AccountList = model.AccountList;
                    SoftContext.AccountList = model.AccountList.ToList();
                    TodayTime = model.TodayTime;
                }
            } 
        }

        /// <summary>
        /// 保存数据到本地
        /// </summary>
        public void SaveToLocal()
        {
            AccountList = new ObservableCollection<Account>(SoftContext.AccountList);
            LocalDataHandler.SetData("data.db", "accounts", this);
        }
    }
}
