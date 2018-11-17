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
            Process CmdProcess = new Process();
            CmdProcess.StartInfo.FileName = "cmd.exe";
            CmdProcess.StartInfo.CreateNoWindow = true;         // 不创建新窗口    
            CmdProcess.StartInfo.UseShellExecute = false;       //不启用shell启动进程  
            CmdProcess.StartInfo.RedirectStandardInput = true;  // 重定向输入    
            CmdProcess.StartInfo.RedirectStandardOutput = true; // 重定向标准输出    
            CmdProcess.StartInfo.RedirectStandardError = true;  // 重定向错误输出  
            CmdProcess.StandardInput.WriteLine(cmd + "&exit"); //向cmd窗口发送输入信息  
            CmdProcess.StandardInput.AutoFlush = true;  //提交  
            CmdProcess.Start();//执行  
            string result=CmdProcess.StandardOutput.ReadToEnd();//输出  
            CmdProcess.WaitForExit();//等待程序执行完退出进程  
            CmdProcess.Close();//结束 
            return result;
        }
    }
}
