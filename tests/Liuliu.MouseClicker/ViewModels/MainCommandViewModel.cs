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
using Liuliu.MouseClicker.Contexts;
using System.IO;
using Liuliu.ScriptEngine.Damo;
using Liuliu.MouseClicker.Models;

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
                    SoftContext.UpdateSimulator();
                    foreach (YeShenSimulator item in SoftContext.YeShenSimulatorList)
                    {

                        IRole role = new Role(item.NoxHwnd);
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
                        if (SoftContext.Locator.Main.Roles.Where(x => x.Window.Hwnd == item.NoxHwnd).Count() > 0)
                        {
                            Debug.WriteLine("该句柄已经存在！");
                        }
                        else
                        {
                            SoftContext.Locator.Main.Roles.Add((Role)role);
                        }
                       
                    }
                    foreach (var item in SoftContext.Locator.Main.Roles.ToList())
                    {
                        if (item.Window.IsAlive == false)
                        {
                            if (item.TaskEngine.IsWorking)
                                item.TaskEngine.Stop();
                            SoftContext.Locator.Main.Roles.Remove(item);
                        }
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
                   
                    List<TaskBase> tasks = new List<TaskBase>();

                    if (role.SelectedItemTask.Content.ToString() == "日常任务")
                    {
                        tasks.Add(new RichangTask(new TaskContext(role, new Function() { Name = "日常任务" })));
                    }
                    if (role.SelectedItemTask.Content.ToString() == "活动任务")
                    {
                        tasks.Add(new HuodongTask(new TaskContext(role, new Function() { Name = "活动任务" })));
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
                    try
                    {
                        Account account = SoftContext.GetAccount();
                        if (account == null)
                        {
                            Debug.WriteLine("所有帐号已经执行完毕!");
                            return;
                        }
                        YeShenSimulator ysSimulator=SoftContext.YeShenSimulatorList.FirstOrDefault(x => x.NoxHwnd == role.Hwnd);
                            //窗口绑定
                        DmPlugin dm = role.Window.Dm;
                        bool flag;
                        flag = Delegater.WaitTrue(() => role.Window.BindHalfBackgroundMoniqi(), () => dm.Delay(1000), 10);
                        if (!flag)
                        {
                            throw new Exception("角色绑定失败，请添加杀软信任，右键以管理员身份运行，Win7系统请确保电脑账户为“Administrator”");
                        }
                        dm.DownCpu(20);
                        string result=CmdHelper.ExecuteCmd(@"E:\nox\Nox\bin\nox_adb shell dumpsys window w|findstr \/|findstr name=");
                        if (result.IndexOf("com.regin.gcld.fl/com.regin.gcld.fl.gcld") < 0)
                        {
                            CmdHelper.ExecuteCmd(@"E:\nox\Nox\bin\nox_adb -s " + SoftContext.YeShenSimulatorList.FirstOrDefault(x => x.NoxHwnd == role.Hwnd).AdbDevicesId + " shell am start -n com.regin.gcld.fl/.gcld");
                            Delegater.WaitTrue(() => dm.IsExistPic(279, 37, 476, 100, @"\bmp\飞流帐号登录.bmp", 0.9), () => dm.Delay(1000));
                        }
                        if(dm.IsExistPic(279, 37, 476, 100, @"\bmp\飞流帐号登录.bmp", 0.9))
                        {
                            dm.Delay(1000);
                            dm.MoveToClick(562, 156);
                            dm.Delay(500);
                            for (int i = 0; i < 20; i++)
                            {
                                if (dm.GetColorNum(292,121,414,176, "ffffff-101010",0.9)>5)
                                {
                                    CmdHelper.ExecuteCmd(@"E:\nox\Nox\bin\nox_adb -s " + ysSimulator.AdbDevicesId + " shell input keyevent 67&" +
                                                               "nox_adb -s " + ysSimulator.AdbDevicesId + " shell input keyevent 67&" +
                                                               @"E:\nox\Nox\bin\nox_adb -s " + ysSimulator.AdbDevicesId + " shell input keyevent 67&" +
                                                               @"E:\nox\Nox\bin\nox_adb -s " + ysSimulator.AdbDevicesId + " shell input keyevent 67"
                                                               );
                                }
                                else
                                    break;

                            }
                            
                            CmdHelper.ExecuteCmd(@"E:\nox\Nox\bin\nox_adb -s " + ysSimulator.AdbDevicesId +" shell input text \""+account.UserName+"\"");
                            dm.Delay(1000);
                            dm.MoveToClick(577, 218);
                            dm.Delay(500);
                            for (int i = 0; i < 20; i++)
                            {
                                if (dm.GetColorNum(290,192,444,245, "ffffff-101010", 0.9) > 5)
                                {
                                    CmdHelper.ExecuteCmd(@"E:\nox\Nox\bin\nox_adb -s " + ysSimulator.AdbDevicesId + " shell input keyevent 67&" +
                                                               "nox_adb -s " + ysSimulator.AdbDevicesId + " shell input keyevent 67&" +
                                                               @"E:\nox\Nox\bin\nox_adb -s " + ysSimulator.AdbDevicesId + " shell input keyevent 67&" +
                                                               @"E:\nox\Nox\bin\nox_adb -s " + ysSimulator.AdbDevicesId + " shell input keyevent 67"
                                                               );
                                }
                                else
                                    break;
                               
                            }
                            CmdHelper.ExecuteCmd(@"E:\nox\Nox\bin\nox_adb -s " + SoftContext.YeShenSimulatorList.FirstOrDefault(x => x.NoxHwnd == role.Hwnd).AdbDevicesId + " shell input text \"" + account.Password + "\"");
                            dm.Delay(1000);
                            dm.FindPicAndClick(413, 279, 543, 348, @"\bmp\登录.bmp");
                            dm.Delay(8000);
                        }
                        // engine.Start(tasks.ToArray());
                    }
                    catch(Exception ex)
                    {
                        role.OutMessage(ex.Message);
                    }
                  

                });
            }
        }
    
        public delegate void delegateHandler(string responseStr);
        public delegateHandler handle;

        AutoResetEvent autoReset = new AutoResetEvent(false);
        ADBCommand adbObj;

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