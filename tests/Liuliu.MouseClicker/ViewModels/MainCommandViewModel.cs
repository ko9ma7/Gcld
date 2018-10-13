// -----------------------------------------------------------------------
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
                        
                        IRole role = new Role(item);
                        DmPlugin dm = role.Window.Dm;
                
                        if(role.Window.ClientSize.Item1!=960||role.Window.ClientSize.Item2!=540)
                        {
                            Debug.WriteLine("模拟器窗口大小未设置为960*540,请重新设置！");
                            Debug.WriteLine("当前窗口大小：" + role.Window.ClientSize.Item1 + "*" + role.Window.ClientSize.Item2);
                            continue;
                        }
                        dm.SetPath(AppDomain.CurrentDomain.BaseDirectory);
                        dm.SetDict(0, "dict.txt");
                        dm.UseDict(0);

                        if (SoftContext.Locator.Main.Roles.Where(x=>x.Window.Hwnd==item).Count()>0)
                        {
                            Debug.WriteLine("该句柄已经存在！");
                        }
                        else
                        {
                            SoftContext.Locator.Main.Roles.Add((Role)role);
                        }
                        Function func = new Function();
                        func.Name = "日常任务";

                        TaskEngine engine = new TaskEngine();
                        TaskContext context = new TaskContext(role, func);
                        engine.OutMessage = (str) => { Debug.WriteLine(str); };
                        engine.Window = role.Window;

                        Role r = (Role)role;
                        List<TaskBase> tasks = new List<TaskBase>();
                       // tasks.Add(new RichangTask(context));
                        tasks.Add(new HuodongTask(context));
                        engine.Start(tasks.ToArray());
                    }

                });
            }
        }
    }
}