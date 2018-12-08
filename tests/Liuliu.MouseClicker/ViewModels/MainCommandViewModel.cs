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
        public MainCommandViewModel()
        {
            Messenger.Default.Register<SendData<Account>>(this, Notifications.MainCommandViewModel,
               (sendData) =>
               {
                   Account account = sendData.Data;
                   switch (sendData.Message)
                   {
                       case "Login":
                           Start(_role,account);
                           break;
                       case "Stop":
                           _role.TaskEngine.Stop();
                           account.IsWorking = false;
                           break;
                   }
               });
        }

        private Role _role;
      

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
                return new RelayCommand<Role>((role) =>
                {
                    // Messenger.Default.Send("OpenRoleSettingFlyout", "RoleSettingFlyout");
                    
                    Messenger.Default.Send(role, "XilianFlyout");
                });
            }
        }
        
        public ICommand OpenAllAccountFlyoutCommand
        {
            get
            {
                return new RelayCommand<Role>((role) =>
                {
                    _role = role;
                    Messenger.Default.Send(true, Notifications.AccountFlyout);
                });
            }
        }
        public ICommand OpenAccountFlyoutCommand
        {
            get
            {
                return new RelayCommand<Role>((role) =>
                {
                    _role = role;
                    Messenger.Default.Send("OpenAccountFlyout", Notifications.AccountFlyout);
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
                            if(role.Window.ClientSize.Item1==538&&role.Window.ClientSize.Item2==956)
                            {

                            }
                            else
                            {
                                Debug.WriteLine("模拟器窗口大小未设置为960*540,请重新设置！");
                                Debug.WriteLine("当前窗口大小：" + role.Window.ClientSize.Item1 + "*" + role.Window.ClientSize.Item2);
                                continue;
                            }
                        }
                        dm.SetPath(AppDomain.CurrentDomain.BaseDirectory);
                        dm.SetDict(0, "dict.txt");
                        dm.SetDict(1, "number.txt");
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
                return new RelayCommand<Role>((role) => {
                    Start(role, null);
                }); 
            }
        }

        public void Start(Role role,Account account)
        {
            Function func = new Function();
            func.Name = "任务";

            TaskContext context = new TaskContext(role, func);
            TaskEngine engine = role.TaskEngine;

            List<TaskBase> tasks = new List<TaskBase>();

            engine.AutoLogin = () => AutoLogin(role, account);
            engine.ChangeRole = () => role.ChangeRole();
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
                engine.AutoLogin = null;
                context.Settings.StepName = "自动兵器";
                tasks.Add(new SmallTool(context));
            }
            if (role.SelectedItemTask.Content.ToString() == "自动洗练")
            {
                engine.AutoLogin = null;
                engine.ChangeRole = null;
                context.Settings.StepName = "自动洗练";
                tasks.Add(new SmallTool(context));
            }
            if (role.SelectedItemTask.Content.ToString() == "指定洗练")
            {
                engine.AutoLogin = null;
                engine.ChangeRole = () => { return false; };
                context.Settings.StepName = "指定洗练";
                context.Settings.EquipmentType = role.SelectedIndex;
                tasks.Add(new SmallTool(context));
            }
            if (role.SelectedItemTask.Content.ToString() == "自动建筑")
            {
                context.Settings.StepName = "自动建筑";
                tasks.Add(new SmallTool(context));
            }
            if (role.SelectedItemTask.Content.ToString() == "自动主线")
            {
                tasks.Add(new AutoLevel(context));
            }

            if (role.SelectedItemTask.Content.ToString() == "刷新装备")
            {
                context.Settings.StepName = "刷新装备";
                tasks.Add(new SmallTool(context));
            }
            if (role.SelectedItemTask.Content.ToString() == "购买装备")
            {
                engine.AutoLogin = null;
                context.Settings.StepName = "购买装备";
                tasks.Add(new SmallTool(context));
            }
            if (role.SelectedItemTask.Content.ToString() == "自动副本")
            {
                engine.AutoLogin = null;
                context.Settings.StepName = "自动副本";
                tasks.Add(new SmallTool(context));
            }
            try
            {
                engine.Start(tasks.ToArray());
            }
            catch (Exception ex)
            {
                role.OutMessage(ex.Message);
            }
        }
        public bool AutoLogin(Role role,Account account)
        {
            if (account == null)
            {
                 account= SoftContext.GetAccount();
                if (account == null)
                {
                    Debug.WriteLine("所有帐号已经执行完毕!");
                    return false;
                }
            }
            if (role == null)
                return false;
            if (account.IsFinished == true)
                return false;
            role.AccountName = account.UserName;
            bool result = false;
            account.IsWorking = true;
            switch (account.Platform)
            {
                case Platform.飞流:
                    result = FeiliuLogin(account, role);
                    break;
                case Platform.楚游:
                    result = FeiliuLogin(account, role);
                    break;
            }
            if(result)
            {
               // account = null;
                return true;
            }
            return false;
        }
        private bool FeiliuLogin(Account account, Role role)
        {
            DmPlugin Dm = role.Window.Dm;
            YeShenSimulator ysSimulator = SoftContext.YeShenSimulatorList.FirstOrDefault(x => x.NoxHwnd == role.Hwnd);
             string noxPath = "";
            if (File.Exists(@"E:\nox\Nox\bin\nox_adb.exe"))
                noxPath = @"E:\nox\Nox\bin\";
            if(File.Exists(@"E:\Nox\bin\nox_adb.exe"))
                noxPath = @"E:\Nox\bin\";
            string result = CmdHelper.ExecuteCmd(noxPath + @"nox_adb -s " + ysSimulator.AdbDevicesId + @" shell dumpsys window w|findstr \/|findstr name=");
            result = result.Replace("mSurface=Surface(name=", "").Replace(")", "");
            //com.regin.gcld.fl/com.regin.gcld.fl.gcld
            if (result.IndexOf("gcld") > 0) //当前应用程序是攻城掠地
            {
                int index = result.IndexOf('/');
                CmdHelper.ExecuteCmd(noxPath + @"nox_adb -s " + ysSimulator.AdbDevicesId + " shell am force-stop " + result.Remove(index, result.Length - index));
                Dm.Delay(5000);
            }
            switch (account.Platform)
            {
                case Platform.飞流:
                    CmdHelper.ExecuteCmd(noxPath + @"nox_adb -s " + ysSimulator.AdbDevicesId + " shell am start -n com.regin.gcld.fl/.gcld");
                    Delegater.WaitTrue(() => Dm.IsExistPic(279, 37, 476, 100, @"\bmp\飞流帐号登录.bmp", 0.9), () => Dm.Delay(1000), 20);
                    Dm.Delay(1000);
                    if (Dm.IsExistPic(279, 37, 476, 100, @"\bmp\飞流帐号登录.bmp", 0.9))
                    {
                        Dm.Delay(1000);
                        Dm.MoveToClick(562, 156);
                        Dm.Delay(500);
                        for (int i = 0; i < 20; i++)
                        {
                            if (Dm.GetColorNum(292, 121, 414, 176, "ffffff-101010", 0.9) > 5)
                            {
                                CmdHelper.ExecuteCmd(string.Format("{0}nox_adb -s {1} shell input keyevent 67", noxPath, ysSimulator.AdbDevicesId));
                                Dm.Delay(200);
                            }
                            else
                                break;

                        }

                        CmdHelper.ExecuteCmd(noxPath + @"nox_adb -s " + ysSimulator.AdbDevicesId + " shell input text \"" + account.UserName + "\"");
                        Dm.Delay(1000);
                        Dm.MoveToClick(577, 218);
                        Dm.Delay(500);
                        for (int i = 0; i < 20; i++)
                        {
                            if (Dm.GetColorNum(290, 192, 444, 245, "ffffff-101010", 0.9) > 5)
                            {
                                CmdHelper.ExecuteCmd(noxPath + @"nox_adb -s " + ysSimulator.AdbDevicesId + " shell input keyevent 67");
                                Dm.Delay(200);
                            }
                            else
                                break;

                        }
                        CmdHelper.ExecuteCmd(noxPath + "nox_adb -s " + ysSimulator.AdbDevicesId + " shell input text \"" + account.Password + "\"");
                        Dm.Delay(1000);
                        Dm.FindPicAndClick(413, 279, 543, 348, @"\bmp\登录.bmp");

                        return Delegater.WaitTrue(() => {
                            if (Dm.IsExistPic(818, 281, 953, 447, @"\bmp\世界.bmp") || Dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp"))
                            {
                                while(Dm.IsExistPic(406, 378, 557, 432, @"\bmp\以后再说.bmp",0.8))
                                {
                                    Dm.MoveToClick(544, 414);
                                    Dm.Delay(1000);
                                }
                                Dm.Delay(1000);
                                return true;
                            }
                            return false;
                            },() => Dm.Delay(1000), 25);


                    }
                    break;

                case Platform.楚游:
                    CmdHelper.ExecuteCmd(noxPath + @"nox_adb -s " + ysSimulator.AdbDevicesId + " shell am start -n com.regin.gcld.sy/.gcld");
                    Delegater.WaitTrue(() => Dm.GetColorNum(113, 288, 193, 317, "f6c246-202020", 0.9) > 1000, () => Dm.Delay(1000), 20);
                    Dm.Delay(1000);
                    if (Dm.GetColorNum(113,288,193,317,"f6c246-202020",0.9)>1000)
                    {
                        Dm.Delay(1000);
                        Dm.MoveToClick(233, 203);
                        Dm.Delay(500);
                        for (int i = 0; i < 20; i++)
                        {
                            if (Dm.GetColorNum(67, 187, 210, 216, "242424-202030", 0.9) > 5)
                            {
                                CmdHelper.ExecuteCmd(string.Format("{0}nox_adb -s {1} shell input keyevent 67", noxPath, ysSimulator.AdbDevicesId));
                                Dm.Delay(200);
                            }
                            else
                                break;

                        }
                        CmdHelper.ExecuteCmd(noxPath + @"nox_adb -s " + ysSimulator.AdbDevicesId + " shell input text \"" + account.UserName + "\"");
                        Dm.Delay(1000);
                        Dm.MoveToClick(235, 246);
                        Dm.Delay(500);
                        for (int i = 0; i < 20; i++)
                        {
                            if (Dm.GetColorNum(70, 230, 209, 263, "242424-202030", 0.9) > 5)
                            {
                                CmdHelper.ExecuteCmd(string.Format("{0}nox_adb -s {1} shell input keyevent 67", noxPath, ysSimulator.AdbDevicesId));
                                Dm.Delay(200);
                            }
                            else
                                break;

                        }
                        CmdHelper.ExecuteCmd(noxPath + "nox_adb -s " + ysSimulator.AdbDevicesId + " shell input text \"" + account.Password + "\"");
                        Dm.Delay(500);
                        Dm.MoveToClick(149, 302);

                        return Delegater.WaitTrue(() => {
                            if (Dm.IsExistPic(818, 281, 953, 447, @"\bmp\世界.bmp") || Dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp"))
                            {
                                //while (Dm.IsExistPic(406, 378, 557, 432, @"\bmp\以后再说.bmp", 0.8))
                                //{
                                //    Dm.MoveToClick(544, 414);
                                //    Dm.Delay(1000);
                                //}
                                //Dm.Delay(1000);
                                return true;
                            }
                            return false;
                        }, () => Dm.Delay(1000), 25);


                    }
                    break;
            }
            return false;
        }



        public ICommand StopCommand
        {
            get
            {
                return new RelayCommand<Role>((role) =>
                {
                    role.TaskEngine.Stop();
                    Account account=SoftContext.Locator.Accounts.AccountList.FirstOrDefault(x=>x.UserName==role.AccountName);
                    if (account != null)
                        account.IsWorking = false;
                });
            }
        }
    }
}