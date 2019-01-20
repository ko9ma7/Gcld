// -----------------------------------------------------------------------
//  <copyright file="ClickSettingViewModel.cs" company="柳柳软件">
//      Copyright (c) 2017 66SOFT. All rights reserved.
//  </copyright>
//  <site>http://www.66soft.net</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2017-12-23 15:18</last-date>
// -----------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;

using Liuliu.MouseClicker.Mvvm;
using Liuliu.ScriptEngine;
using Liuliu.ScriptEngine.Damo;
using System.Diagnostics;
using Newtonsoft.Json;
using GalaSoft.MvvmLight.Messaging;
using System.IO;
using Liuliu.MouseClicker.Contexts;
using System.Collections.ObjectModel;

namespace Liuliu.MouseClicker.ViewModels
{
    public class ActivityItem
    {
        public Activity Activity { get; set; }
        public bool IsChecked { get; set; }
    }
    public class RoleSettingViewModel : ViewModelExBase
    {
        public RoleSettingViewModel()
        {
            _name = "";
            _activityList = new ObservableCollection<ActivityItem>();
            _activityList.Add(new ActivityItem() { Activity = Activity.万邦来朝, IsChecked = false });
            _activityList.Add(new ActivityItem() { Activity = Activity.古城探宝, IsChecked = false });
            _activityList.Add(new ActivityItem() { Activity = Activity.草船借箭, IsChecked = false });
            _activityList.Add(new ActivityItem() { Activity = Activity.天降神剑, IsChecked = false });
            _activityList.Add(new ActivityItem() { Activity = Activity.海岛寻宝, IsChecked = false });
            _activityList.Add(new ActivityItem() { Activity = Activity.宝石矿脉, IsChecked = false });
            _activityList.Add(new ActivityItem() { Activity = Activity.大宴群雄, IsChecked = false });

        }
        private ObservableCollection<ActivityItem> _activityList;
        public ObservableCollection<ActivityItem> ActivityList
        {
            get { return _activityList; }
            set
            {
                SetProperty(ref _activityList, value, () => ActivityList);
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value, () => Name);
            }
        }


        [JsonIgnore]
        public ICommand DmFileBrowseCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send("DmFileBrowse", "SettingsFlyout");
                });
            }
        }

        [JsonIgnore]
        public override string Error
        {
            get
            {
                //if (!File.Exists(DmFile))
                //{
                //    return "大漠插件文件不存在";
                //}
                //if (DmRegCodeShow && DmRegCode.IsMissing())
                //{
                //    return "大漠注册码不能为空";
                //}
                return base.Error;
            }
        }

        /// <summary>
        /// 从本地数据初始化
        /// </summary>
        public void InitFromLocal()
        {
            var model = LocalDataHandler.GetData<RoleSettingViewModel>("data.db", _name);
            if (model != null)
            {
                Name = model.Name;
                
            }
        }

        /// <summary>
        /// 保存数据到本地
        /// </summary>
        public void SaveToLocal()
        {
            LocalDataHandler.SetData("data.db", _name, this);
        }
    }
}