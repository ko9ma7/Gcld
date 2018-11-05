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
using System.Threading;
using System.Windows.Controls;

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
        public ICommand RefreshCommand
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

                        if (role.Window.ClientSize.Item1 != 960 || role.Window.ClientSize.Item2 != 540)
                        {
                            Debug.WriteLine("模拟器窗口大小未设置为960*540,请重新设置！");
                            Debug.WriteLine("当前窗口大小：" + role.Window.ClientSize.Item1 + "*" + role.Window.ClientSize.Item2);
                            continue;
                        }
                        dm.SetPath(AppDomain.CurrentDomain.BaseDirectory);
                        dm.SetDict(0, "dict.txt");
                        dm.SetDict(1, "number.txt");
                        dm.SetDict(2, "maintask.txt");
                        dm.UseDict(0);
                        if (SoftContext.Locator.Main.Roles.Where(x => x.Window.Hwnd == item).Count() > 0)
                        {
                            Debug.WriteLine("该句柄已经存在！");
                        }
                        else
                        {
                            SoftContext.Locator.Main.Roles.Add((Role)role);
                        }
                       
                    }
                    List<Role> roles=SoftContext.Locator.Main.Roles.Where(x => x.Window.IsAlive == false).ToList<Role>();
                    foreach (var item in roles)
                    {

                        SoftContext.Locator.Main.Roles.Remove(item);
                    }
                   

                });
            }
        }

             public ICommand BeginCommand
        {
            get
            {
                return new RelayCommand<Role>((role) =>
                {
                  
                    Function func = new Function();
                    func.Name = "任务";

                    TaskContext context = new TaskContext(role, func);
                    TaskEngine engine = role.TaskEngine;
                   
                    engine.OutMessage = (str) => { Debug.WriteLine("[" + Thread.CurrentThread.ManagedThreadId.ToString() + "]" + str); };
                    List<TaskBase> tasks = new List<TaskBase>();

                    if (role.SelectedItemTask.Content.ToString() == "日常任务")
                    {
                        tasks.Add(new RichangTask(context));
                    }
                    if (role.SelectedItemTask.Content.ToString() == "活动任务")
                    {
                        tasks.Add(new HuodongTask(context));
                    }
                    if (role.SelectedItemTask.Content.ToString() == "自动兵器")
                    {
                        context.Settings.IsAutoWeapon = true;
                        tasks.Add(new SmallTool(context));
                    }
                    if (role.SelectedItemTask.Content.ToString() == "自动洗练")
                    {
                        context.Settings.IsAutoClear = true;
                        tasks.Add(new SmallTool(context));
                    }
                    if (role.SelectedItemTask.Content.ToString() == "自动建筑")
                    {
                        context.Settings.IsAutoBuilding = true; 
                        tasks.Add(new SmallTool(context));
                    }
                    if (role.SelectedItemTask.Content.ToString() == "自动主线")
                    {
                        tasks.Add(new AutoLevel(context));
                    }
                    
                    if (role.SelectedItemTask.Content.ToString() == "刷新装备")
                    {
                        context.Settings.IsRefreshEquipment = true;
                        tasks.Add(new SmallTool(context));
                    }
                    engine.Cycle = 10;
                    engine.OnCycleEnd = () => role.ChangeRole();
                    engine.Start(tasks.ToArray());

                });
            }
        }
             public ICommand StopCommand
        {
            get
            {
                return new RelayCommand<Role>((role) =>
                {
                    role.TaskEngine.Stop();
                });
            }
        }
    }
}