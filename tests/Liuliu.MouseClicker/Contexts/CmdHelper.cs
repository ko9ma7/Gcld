using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Contexts
{
    public class CmdHelper
    {
        public static string ExecuteCmd(string cmd)
        {
            try
            {
                using (Process CmdProcess = new Process())
                {
                    CmdProcess.StartInfo.FileName = "cmd.exe";
                    CmdProcess.StartInfo.CreateNoWindow = true;         // 不创建新窗口    
                    CmdProcess.StartInfo.UseShellExecute = false;       //不启用shell启动进程  
                    CmdProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入    
                    CmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出    
                    CmdProcess.Start();//执行  

                    CmdProcess.StandardInput.WriteLine(cmd + "&exit"); //向cmd窗口发送输入信息  
                    CmdProcess.StandardInput.AutoFlush = true;  //提交  
                  
                    string result = CmdProcess.StandardOutput.ReadToEnd();//输出  
                    CmdProcess.WaitForExit();//等待程序执行完退出进程  
                    CmdProcess.Close();//结束 
                    return result;
                }
                   
                
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return "";
        }

        /// <summary>
        /// 获取已安装的软件列表
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static List<string> GetInstalledSoftwaresList()
        {
            try
            {
                List<string> InstalledSoftwareList = new List<string>();
                var _with1 = InstalledSoftwareList;
                _with1.Add("[[已安装的软件]]");
                //HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall
                RegistryKey Keys = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall");
                string[] S = Keys.GetSubKeyNames();
                foreach (string tms in S)
                {
                    Keys = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + tms, true);
                    string K = Keys.GetValue("DisplayName", "").ToString();
                    if (K.Length != 0)
                    {
                        _with1.Add("[" + K + "]");
                        _with1.Add(K + "/");
                    }
                    K = Keys.GetValue("InstallLocation", "").ToString();
                    if (K.Length != 0)
                    {
                        _with1.Add("安装目录:/" + K);
                    }
                  
                    Keys.Close();
                }
                return InstalledSoftwareList;
            }
            catch
            {
            }
            return new List<string>();
        }
    }
}
