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
            allList = new List<Account>()
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
        private List<Account> allList = null;

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
        public void InitFromLocal(bool showAll=false)
        {
            var model = LocalDataHandler.GetData<AccountViewModel>("data.db", "accounts");
            if (model != null)
            {
                if (model.TodayTime != DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    //不是当天日期,初始化所有数据
                    AccountList = new ObservableCollection<Account>(allList);  //新建一个对象
                    TodayTime = DateTime.Now.ToString("yyyy-MM-dd");
                }
                else
                {
                    //是当天日期,从本地加载数据
                    allList = model.AccountList.ToList();
                    if(showAll==false)
                        AccountList = new ObservableCollection<Account>(allList.Where(x => x.IsFinished == false));
                    else
                        AccountList = new ObservableCollection<Account>(allList);
                    TodayTime = model.TodayTime;
                }
            } 
        }

        /// <summary>
        /// 保存数据到本地
        /// </summary>
        public void SaveToLocal()
        {
            AccountList = new ObservableCollection<Account>(allList);
            
            LocalDataHandler.SetData("data.db", "accounts", this);
        }
    }
}
