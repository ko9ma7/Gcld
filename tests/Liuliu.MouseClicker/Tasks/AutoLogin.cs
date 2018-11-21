using Liuliu.MouseClicker.Contexts;
using Liuliu.MouseClicker.Models;
using Liuliu.ScriptEngine;
using Liuliu.ScriptEngine.Damo;
using Liuliu.ScriptEngine.Models;
using Liuliu.ScriptEngine.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Tasks
{
    public class AutoLogin : TaskBase
    {
        public AutoLogin(TaskContext context) : base(context)
        {
        
        }

        protected override int GetStepIndex(TaskContext context)
        {
            return 1;
        }

        protected override TaskStep[] StepsInitialize()
        {
            TaskStep[] steps =
             {
                new TaskStep() {Name="自动登陆",Order=1,RunFunc=RunStep1 }

             };
            return steps;
        }
      

        private TaskResult RunStep1(TaskContext context)
        {
            Role role = (Role)context.Role;
            DmPlugin dm = role.Window.Dm;

            Account account = SoftContext.GetAccount();
            if (account == null)
            {
                Debug.WriteLine("所有帐号已经执行完毕!");
                return new TaskResult(TaskResultType.Fail, "所有帐号已经执行完毕!");
            }
            role.AccountName = account.UserName;
            switch(account.Platform)
            {
                case Platform.飞流:
                    FeiliuLogin(account);
                    break;
                case Platform.楚游:
                    FeiliuLogin(account);
                    break;
            }
            Delegater.WaitTrue(() =>
            {

                    return true;
            }, () => dm.Delay(1000));


            return TaskResult.Finished;
        }
       

        private bool FeiliuLogin(Account account)
        {
            Role role = (Role)Role;
            YeShenSimulator ysSimulator = SoftContext.YeShenSimulatorList.FirstOrDefault(x => x.NoxHwnd == ((Role)Role).Hwnd);
            // string noxPath = @"E:\nox\Nox\bin\";
            string noxPath = @"E:\Nox\bin\";
            string result = CmdHelper.ExecuteCmd(noxPath + @"nox_adb -s "+ysSimulator.AdbDevicesId+@" shell dumpsys window w|findstr \/|findstr name=");
            result=result.Replace("mSurface=Surface(name=","").Replace(")", "");
            //com.regin.gcld.fl/com.regin.gcld.fl.gcld
            if (result.IndexOf("gcld") >0) //当前应用程序是攻城掠地
            {
                int index = result.IndexOf('/');
                CmdHelper.ExecuteCmd(noxPath + @"nox_adb -s " + ysSimulator.AdbDevicesId + " shell am force-stop " + result.Remove(index,result.Length-index));
                Dm.Delay(5000);
            }
            CmdHelper.ExecuteCmd(noxPath + @"nox_adb -s " + ysSimulator.AdbDevicesId + " shell am start -n com.regin.gcld.fl/.gcld");
            Delegater.WaitTrue(() => Dm.IsExistPic(279, 37, 476, 100, @"\bmp\飞流帐号登录.bmp", 0.9), () => Dm.Delay(1000));
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

                return Delegater.WaitTrue(() => Dm.IsExistPic(818, 281, 953, 447, @"\bmp\主城.bmp") || Dm.IsExistPic(818, 281, 953, 447, @"\bmp\副本.bmp"),
                                   () => Dm.Delay(1000), 20);
            }
            return false;

        }

    }
}
