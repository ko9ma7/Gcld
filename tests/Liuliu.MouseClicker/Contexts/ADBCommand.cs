using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Contexts
{
        public class ADBCommand
        {
            public delegate void MessageOutputDelegate(string result);
            event MessageOutputDelegate MessageOutputEvent;
            AutoResetEvent autoRet = new AutoResetEvent(false);
            readonly object lockObj = new object();

            public ADBCommand(MessageOutputDelegate ShowResponseMessage)
            {
                MessageOutputEvent = ShowResponseMessage;
            }

            // synchronously 
            public void RunAdbCmd(string szCommand, int timeOut = 10)
            {
                try
                {
                    using (Process p = new Process())
                    {
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.Arguments = "/c" + szCommand;

                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardInput = true;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.RedirectStandardError = true;

                        p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
                        p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

                        p.EnableRaisingEvents = true;
                        p.Exited += new EventHandler(p_Exited);

                        p.Start();

                        p.BeginOutputReadLine();
                        p.BeginErrorReadLine();

                        MessageOutputEvent("[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "]\r\n" + String.Format("[SEND] {0}", szCommand));

                        DateTime now = DateTime.Now;
                        while (!p.HasExited)
                        {
                           // Application.DoEvents();
                            if (DateTime.Now > now.AddSeconds(timeOut))
                            {
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageOutputEvent("[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "]\r\n" + String.Format("[SEND] Error Message => {0}", ex.Message));
                }
            }

            public void RunAdbCmd(List<string> szCommandList, int timeOut = 10)
            {
                try
                {
                    using (Process p = new Process())
                    {
                        p.StartInfo.FileName = "cmd.exe";

                        p.StartInfo.CreateNoWindow = true;
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardInput = true;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.RedirectStandardError = true;

                        p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
                        p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

                        p.EnableRaisingEvents = true;
                        p.Exited += new EventHandler(p_Exited);

                        p.Start();

                        p.BeginOutputReadLine();
                        p.BeginErrorReadLine();

                        StreamWriter streamWriter = p.StandardInput;

                        foreach (string szCommand in szCommandList)
                        {
                            MessageOutputEvent("[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "]\r\n" + String.Format("[SEND] {0}", szCommand));
                            streamWriter.WriteLine(szCommand);
                        }

                        streamWriter.Close();

                        DateTime now = DateTime.Now;
                        while (!p.HasExited)
                        {
                            //Application.DoEvents();
                            if (DateTime.Now > now.AddSeconds(timeOut))
                            {
                                return;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageOutputEvent("[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "]\r\n" + String.Format("[SEND] Error Message => {0}", ex.Message));
                }
            }

            private void p_Exited(object sender, EventArgs e)
            {
                autoRet.Set();
            }

            private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                lock (lockObj)
                {
                    if (e.Data != null && e.Data != string.Empty)
                    {
                        MessageOutputEvent("[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "]\r\n" + "[RECEIVE] " + e.Data);
                    }
                }
            }

            private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
            {
                lock (lockObj)
                {
                    if (e.Data != null && e.Data != string.Empty)
                    {
                        MessageOutputEvent("[" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "]\r\n" + "[RECEIVE] " + e.Data);
                    }
                }
            }
        
    }
}
