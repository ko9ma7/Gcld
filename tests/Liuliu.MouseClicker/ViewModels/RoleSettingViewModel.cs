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
 
    public class RoleSettingViewModel : ViewModelExBase
    {
        public class Function
        {
            public string FunctionName { get; set; }
            public bool IsChecked { get; set; }
        }
        public RoleSettingViewModel()
        {
          
        }
        private ObservableCollection<Function> _utilList;
        public ObservableCollection<Function> UtilList
        {
            get { return _utilList; }
            set
            {
                SetProperty(ref _utilList, value, () => UtilList);
            }
        }
        private ObservableCollection<Function> _activityList;
        public ObservableCollection<Function> ActivityList
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
            else
            {
                if (ActivityList == null)
                {
                    ActivityList = new ObservableCollection<Function>();
                    foreach (var item in Enum.GetValues(typeof(ActivityTasksEnum)))
                    {
                        ActivityList.Add(new Function() { FunctionName = item.ToString(), IsChecked = false });
                    }

                }
                if (UtilList == null)
                {
                    UtilList = new ObservableCollection<Function>();
                    foreach (var item in Enum.GetValues(typeof(DailyTasksEnum)))
                    {
                        UtilList.Add(new Function() { FunctionName = item.ToString(), IsChecked = false });
                    }
                }
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