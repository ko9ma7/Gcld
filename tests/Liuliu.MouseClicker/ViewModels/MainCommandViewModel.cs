﻿// -----------------------------------------------------------------------
//  <copyright file="MainCommandViewModel.cs" company="柳柳软件">
//      Copyright (c) 2017 66SOFT. All rights reserved.
//  </copyright>
//  <site>http://www.66soft.net</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2017-12-15 23:31</last-date>
// -----------------------------------------------------------------------

using System.Windows.Input;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using Liuliu.MouseClicker.Mvvm;
using System.Diagnostics;
using Liuliu.ScriptEngine.Tasks;
using Liuliu.MouseClicker.Tasks;
using Liuliu.ScriptEngine.Models;
using System.Collections.Generic;
using Liuliu.ScriptEngine;
using System;
using System.Linq;

namespace Liuliu.MouseClicker.ViewModels
{
    public class MainCommandViewModel : ViewModelExBase
    {
        public ICommand OpenSettingsFlyoutCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send("OpenSettingsFlyout", "SettingsFlyout");
                });
            }
        }

        public ICommand OpenRoleSettingFlyoutCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send("OpenRoleSettingFlyout", "RoleSettingFlyout");
                    
                });
            }
        }
        public ICommand BeginCommand
        {
            get
            {
                return new RelayCommand(() =>
                {

                    SoftContext.UpdateHwnd();
                  
                    foreach (var item in SoftContext.Hwnds)
                    {
                        TaskEngine engine = new TaskEngine();
                        IRole role = new Role(item);
                   
                        if(SoftContext.Locator.Main.Roles.Where(x=>x.Window.Hwnd==item).Count()>0)
                        {
                            Debug.WriteLine("该句柄已经存在！");
                            continue;
                        }
                        SoftContext.Locator.Main.Roles.Add((Role)role);
                        Function func = new Function();
                        func.Name = "草船借箭";

                        TaskContext context = new TaskContext(role, func);
                        engine.OutMessage = (str) => { Debug.WriteLine(str); };
                        engine.Window = role.Window;
                        List<TaskBase> tasks = new List<TaskBase>();
                        tasks.Add(new LingqujunziTask(context));
                        tasks.Add(new CaochuanjiejianTask(context));
                        

                        engine.Start(tasks.ToArray());
                    }

                });
            }
        }
    }
}