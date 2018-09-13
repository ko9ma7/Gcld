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

namespace Liuliu.MouseClicker.ViewModels
{
    public class RoleSettingViewModel : ViewModelExBase
    {

        private bool _isChecked木牛流马;
        public bool IsChecked木牛流马
        {
            get { return _isChecked木牛流马; }
            set { SetProperty(ref _isChecked木牛流马,value, () => IsChecked木牛流马); 
            }
        }

        private bool _isChecked武将犒赏;
        public bool IsChecked武将犒赏
        {
            get { return _isChecked武将犒赏; }
            set { SetProperty(ref _isChecked武将犒赏, value, () => IsChecked武将犒赏); }
        }

        private bool _isChecked古城探宝;
        public bool IsChecked古城探宝
        {
            get { return _isChecked古城探宝; }
            set { SetProperty(ref _isChecked古城探宝, value, () => IsChecked古城探宝); }
        }
        private bool _isChecked领取军资;
        public bool IsChecked领取军资
        {
            get { return _isChecked领取军资; }
            set { SetProperty(ref _isChecked领取军资, value, () => IsChecked领取军资); }
        }
    }
}