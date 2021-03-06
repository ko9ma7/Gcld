﻿// -----------------------------------------------------------------------
//  <copyright file="MainViewModel.cs" company="柳柳软件">
//      Copyright (c) 2017 66SOFT. All rights reserved.
//  </copyright>
//  <site>http://www.66soft.net</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2017-12-15 12:47</last-date>
// -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;

using Liuliu.MouseClicker.Mvvm;
using Liuliu.ScriptEngine;
using Liuliu.ScriptEngine.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Liuliu.ScriptEngine.Tasks;
using System.Diagnostics;
using Liuliu.MouseClicker.Tasks;
using System;
using System.Linq;
using System.Threading;

namespace Liuliu.MouseClicker.ViewModels
{
    public class MainViewModel : ViewModelExBase
    {
        public MainViewModel()
        {
            _roles = new ObservableCollection<Role>();
        }
        private string _title = "攻城掠地助手";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, () => Title); }
        }

        private string _statusBar;
        public string StatusBar
        {
            get { return _statusBar; }
            set { SetProperty(ref _statusBar, value, () => StatusBar); }
        }

        private ObservableCollection<Role> _roles;

        public ObservableCollection<Role> Roles
        {
            get { return _roles; }
            set { SetProperty(ref _roles, value, () => Roles); }
        }
        private Role _role;
        public Role SelectedRole
        {
            get { return _role; }
            set { SetProperty(ref _role, value, () => SelectedRole); }
        }
    }
  
}