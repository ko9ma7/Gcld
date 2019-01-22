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
    public class UtilItem
    {
        public string FunctionName { get; set; }
        public bool IsChecked { get; set; }
    }
    public class RoleSettingViewModel : ViewModelExBase
    {
        public RoleSettingViewModel()
        {
            _activityList = new ObservableCollection<ActivityItem>();
            _activityList.Add(new ActivityItem() { Activity = Activity.万邦来朝, IsChecked = false });
            _activityList.Add(new ActivityItem() { Activity = Activity.古城探宝, IsChecked = false });
            _activityList.Add(new ActivityItem() { Activity = Activity.草船借箭, IsChecked = false });
            _activityList.Add(new ActivityItem() { Activity = Activity.天降神剑, IsChecked = false });
            _activityList.Add(new ActivityItem() { Activity = Activity.海岛寻宝, IsChecked = false });
            _activityList.Add(new ActivityItem() { Activity = Activity.宝石矿脉, IsChecked = false });
            _activityList.Add(new ActivityItem() { Activity = Activity.大宴群雄, IsChecked = false });

            _utilList = new ObservableCollection<UtilItem>();
            _utilList.Add(new UtilItem() { FunctionName = "领取礼包", IsChecked = false });
            _utilList.Add(new UtilItem() { FunctionName = "领取军资", IsChecked = false });
            _utilList.Add(new UtilItem() { FunctionName = "登录奖励", IsChecked = false });
            _utilList.Add(new UtilItem() { FunctionName = "祭祀资源", IsChecked = false });
            _utilList.Add(new UtilItem() { FunctionName = "军需处", IsChecked = false });
            _utilList.Add(new UtilItem() { FunctionName = "领取俸禄", IsChecked = false });
            _utilList.Add(new UtilItem() { FunctionName = "集市购买", IsChecked = false });

        }
        private ObservableCollection<UtilItem> _utilList;
        public ObservableCollection<UtilItem> UtilList
        {
            get { return _utilList; }
            set
            {
                SetProperty(ref _utilList, value, () => UtilList);
            }
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

        private bool _activityShow;
        [JsonIgnore]
        public bool ActivityShow
        {
            get { return _activityShow; }
            set
            {
                SetProperty(ref _activityShow, value, () => ActivityShow);
            }
        }
        private bool _utilShow;
        [JsonIgnore]
        public bool UtilShow
        {
            get { return _utilShow; }
            set
            {
                SetProperty(ref _utilShow, value, () => UtilShow);
            }
        }


        /// <summary>
        /// 从本地数据初始化
        /// </summary>
        public void InitFromLocal()
        {
            var model = LocalDataHandler.GetData<RoleSettingViewModel>("data.db", "roleSetting");
            if (model != null)
            {
                UtilList = model.UtilList;
                ActivityList = model.ActivityList;
            }
        }

        /// <summary>
        /// 保存数据到本地
        /// </summary>
        public void SaveToLocal()
        {
            LocalDataHandler.SetData("data.db", "roleSetting", this);
        }
    }
}