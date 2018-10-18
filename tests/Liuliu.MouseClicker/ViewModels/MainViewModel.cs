// -----------------------------------------------------------------------
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


        public ICommand BeginCommand
        {
            get
            {
                return new RelayCommand<int>((hwnd) =>
                {
                    IRole role = new Role(hwnd);
                    Function func = new Function();
                    func.Name = "日常任务";

                    TaskEngine engine = new TaskEngine();
                    TaskContext context = new TaskContext(role, func);
                    engine.OutMessage = (str) => { Debug.WriteLine("[" + Thread.CurrentThread.ManagedThreadId.ToString() + "]" + str); };
                    engine.Window = role.Window;

                    Role r = (Role)role;
                    List<TaskBase> tasks = new List<TaskBase>();
                    //tasks.Add(new RichangTask(context));
                    // tasks.Add(new HuodongTask(context));
                    tasks.Add(new SmallTool(context));
                    engine.Start(tasks.ToArray());

                });
            }
        }
        public ICommand StopCommand
        {
            get
            {
                return new RelayCommand<int>((hwnd) =>
                {

                });
            }
        }
    }
  
}