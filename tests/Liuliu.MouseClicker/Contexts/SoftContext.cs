using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Liuliu.MouseClicker.Contexts;
using Liuliu.MouseClicker.ViewModels;
using Liuliu.ScriptEngine;
using MahApps.Metro.Controls.Dialogs;

using Microsoft.Practices.ServiceLocation;

using OSharp.Utility.Data;
using Liuliu.ScriptEngine.Damo;
using System.Text.RegularExpressions;
using Liuliu.MouseClicker.Models;
using System.Threading;
using System.Collections.ObjectModel;

namespace Liuliu.MouseClicker
{
    public class SoftContext
    {
        static SoftContext()
        {
            Version = GetVersion();
            YeShenSimulatorList = new List<YeShenSimulator>();

        }
        public const string ServerIp = "39.96.32.192";
        public static Dictionary<string, dynamic> CommandList = new Dictionary<string, dynamic>();

        public static MainWindow MainWindow { get; set; }

        public static SoftRunStatus RunStatus { get; set; }

        public static ViewModelLocator Locator { get; } = ServiceLocator.Current.GetInstance<ViewModelLocator>();

        public static Version Version { get; }

        public static DmSystem DmSystem { get; set; }

        public static ProgressDialogController Progress { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public static OperationResult Initialize()
        {
            var settings = Locator.Settings;
            string dmPath = settings.DmFile;
            var result = OperationHelper.GetDmSystem(dmPath);
            if (result.Successed)
            {
                //给SoftContext DmSystem赋值
                DmSystem = result.Data;
                settings.DmVersion = DmSystem.Dm.Ver();
            }
            return new OperationResult(result.ResultType, result.Message);
        }

        /// <summary>
        /// 获取Progress对象
        /// </summary>
        public static Task<ProgressDialogController> GetProgress(string message)
        {
            return GetProgress("请稍候", message);
        }

        /// <summary>
        /// 获取Progress对象
        /// </summary>
        public static async Task<ProgressDialogController> GetProgress(string title, string message)
        {
            if (Progress == null || !Progress.IsOpen)
            {
                Progress = await MainWindow.ShowProgressAsync(title, message);
            }
            else
            {
                Progress.SetMessage(message);
            }
            return Progress;
        }

        /// <summary>
        /// 显示 ShowMessageAsync 弹窗信息
        /// </summary>
        public static async Task<MessageDialogResult> ShowMessageAsync(string title, string message)
        {
            if (Progress != null && Progress.IsOpen)
            {
                await Progress.CloseAsync();
            }
            return await MainWindow.ShowMessageAsync(title, message);
        }

        /// <summary>
        /// 模拟器组
        /// </summary>
        public static List<YeShenSimulator> YeShenSimulatorList { get; set; }


        public static void UpdateSimulator()
        {
            if (DmSystem == null)
            {
                return; ;
            }
            DmPlugin dm = DmSystem.Dm;

            string hwnds = dm.EnumWindow(0, "QWidgetClassWindow", "Qt5QWindowIcon", 3);

            if (hwnds == "")
            {
                Debug.WriteLine("获取句柄失败!");
                return;
            }
            else
            {
                Debug.WriteLine(hwnds);
            }

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";//设置启动的应用程序
            p.StartInfo.UseShellExecute = false;//禁止使用操作系统外壳程序启动进程
            p.StartInfo.RedirectStandardInput = true;//应用程序的输入从流中读取
            p.StartInfo.RedirectStandardOutput = true;//应用程序的输出写入流中
            p.StartInfo.RedirectStandardError = true;//将错误信息写入流
            p.StartInfo.CreateNoWindow = true;//是否在新窗口中启动进程
            p.Start();
            p.StandardInput.WriteLine(@"netstat -aon|findstr ""ESTABLISHED""");
            p.StandardInput.WriteLine("exit");
            Regex reg = new Regex("\\s+", RegexOptions.Compiled);
            string line = "";
            List<NetStat> list = new List<NetStat>();
            while ((line = p.StandardOutput.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.StartsWith("TCP", StringComparison.OrdinalIgnoreCase))
                {
                    line = reg.Replace(line, ",");
                    string[] arr = line.Split(',');
                    if (arr.Length == 5)
                    {
                        if (arr[1].StartsWith("127.0.0.1") && arr[2].StartsWith("127.0.0.1") || arr[2].StartsWith(ServerIp))
                        {
                            NetStat netstat = new NetStat()
                            {
                                Proto = arr[0],
                                LocalAddress = arr[1],
                                ForeignAddress = arr[2],
                                State = arr[3],
                                Pid = arr[4]
                            };
                            list.Add(netstat);
                        }
                    }
                }
            }
            //移除所有不存在的窗口
            YeShenSimulatorList.RemoveAll(x => !dm.GetWindowState(x.NoxHwnd, 0));
            foreach (var hwnd in hwnds.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList())
            {
                YeShenSimulator yss = new YeShenSimulator();
                var s = YeShenSimulatorList.FirstOrDefault(x => x.NoxHwnd == hwnd);
                if (s != null)
                {
                    if (s.NoxVMHandlePid == 0)
                    {
                        yss.NoxHwnd = s.NoxHwnd;
                        yss.NoxPid = s.NoxPid;
                    }
                    else
                        continue;
                }
                else
                {
                    yss.NoxHwnd = hwnd;
                    yss.NoxPid = dm.GetWindowProcessId(hwnd);
                }
                try
                {
                    //找到模拟器Nox所对应连接NoxVMHandle,可能有多个连接
                    List<NetStat> ln1 = list.FindAll(a => a.Pid == yss.NoxPid.ToString());
                    //本地远程相反的连接就是NoxVMHandle,获得NoxVMHandle进程Id,n2为NoxVMHandle进程与Nox一个链接
                    NetStat n2 = list.First(b => b.ForeignAddress == ln1.FirstOrDefault().LocalAddress && b.LocalAddress == ln1.FirstOrDefault().ForeignAddress);
                    //找到该进程id的另一个连接就是adb连接
                    NetStat n3 = list.FirstOrDefault(c => c.Pid == n2.Pid && (ln1.FirstOrDefault(x => x.ForeignAddress == c.LocalAddress)) == null);
                    if (n3 != null)
                    {
                        yss.NoxVMHandlePid = int.Parse(n3.Pid);
                        yss.AdbDevicesId = n3.LocalAddress; //对应的本地地址就是adb设备地址
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                YeShenSimulatorList.Add(yss);

            }
            p.Close();
            Debug.WriteLine("当前打开的模拟器：" + YeShenSimulatorList.Count);

        }
        public static List<NetStat> GetSendIpInfo()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";//设置启动的应用程序
            p.StartInfo.UseShellExecute = false;//禁止使用操作系统外壳程序启动进程
            p.StartInfo.RedirectStandardInput = true;//应用程序的输入从流中读取
            p.StartInfo.RedirectStandardOutput = true;//应用程序的输出写入流中
            p.StartInfo.RedirectStandardError = true;//将错误信息写入流
            p.StartInfo.CreateNoWindow = true;//是否在新窗口中启动进程
            p.Start();
            p.StandardInput.WriteLine(@"netstat -aon|findstr ""ESTABLISHED""|findstr " + ServerIp);
            p.StandardInput.WriteLine("exit");
            Regex reg = new Regex("\\s+", RegexOptions.Compiled);
            string line = "";
            List<NetStat> list = new List<NetStat>();
            while ((line = p.StandardOutput.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.StartsWith("TCP", StringComparison.OrdinalIgnoreCase))
                {
                    line = reg.Replace(line, ",");
                    string[] arr = line.Split(',');
                    if (arr.Length == 5)
                    {
                        if(arr[2].StartsWith(ServerIp))
                        {
                            string[] ss = arr[1].Split(':');
                            string[] dd = arr[2].Split(':');
                            NetStat netstat = new NetStat()
                            {
                                LocalAddress = ss[0],
                                SrcPort = ss[1],
                                ForeignAddress = dd[0],
                                DstPort = dd[1],
                                Pid = arr[4]
                            };
                            list.Add(netstat);
                        }
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// 关闭 Progress 弹窗  
        /// </summary>
        public static async Task ProgressCloseAsync()
        {
            if (Progress.IsOpen)
            {
                await Progress.CloseAsync();
            }
        }

        private static Version GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            if (assembly.Location != null)
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                return new Version(fvi.FileVersion);
            }
            return new Version("0.0.0.1");
        }
        // 为保证线程安全，使用一个锁来保护_task的访问
        readonly static object _locker = new object();
        // 通过 _wh 给工作线程发信号
        static EventWaitHandle _wh = new AutoResetEvent(false);
        public static Account GetAccount()
        {
            lock (_locker)
            {
                var account = Locator.Accounts.AccountList.FirstOrDefault(x => x.IsFinished == false && x.IsWorking == false);
                if (account != null)
                {
                    return account;
                }
                return null;
            }

        }

    }
    public class NetStat
    {
        public string Proto { get; set; }
        public string LocalAddress { get; set; }
        public string SrcPort { get; set; }
        public string DstPort { get; set; }
        public string ForeignAddress { get; set; }
        public string State { get; set; }
        public string Pid { get; set; }
    }
}
