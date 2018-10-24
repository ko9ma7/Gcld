using EasyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Hook
{
    public class Main : IEntryPoint
    {
        SocketInterFace Interface;
        Stack<String> Queue = new Stack<String>();

        public Main(RemoteHooking.IContext InContext, string InChannelName)
        {
            Interface =RemoteHooking.IpcConnectClient<SocketInterFace>(InChannelName);
            Interface.OnLog("初始化HOOK成功");
        }
        LocalHook RecvHook;
        LocalHook SendHook;


        int MyRecv(IntPtr socket, IntPtr buffer, int length, int flags)
        {
            int bytesCount = recv(socket, buffer, length, flags);
            if (bytesCount > 0)
            {
                byte[] RecvBuffer = new byte[bytesCount];
                Marshal.Copy(buffer, RecvBuffer, 0, RecvBuffer.Length);
                Interface.OnRecv(RecvBuffer, 0, 0);
            }
            return bytesCount;
        }
        int MySend(IntPtr socket, IntPtr buffer, int length, int flags)
        {
            int bytesCount = send(socket, buffer, length, flags);
            if (bytesCount > 0)
            {
                byte[] RecvBuffer = new byte[bytesCount];
                Marshal.Copy(buffer, RecvBuffer, 0, RecvBuffer.Length);
                Interface.OnSend(RecvBuffer, 0, 0);
            }
            return bytesCount;
        }
        public void Run(RemoteHooking.IContext InContext, string InChannelName)
        {
            RecvHook = LocalHook.Create(LocalHook.GetProcAddress("WS2_32.dll", "recv"), new DRecv(MyRecv), this);
            SendHook = LocalHook.Create(LocalHook.GetProcAddress("WS2_32.dll", "send"), new DSend(MySend), this);

            SendHook.ThreadACL.SetExclusiveACL(new Int32[] { 0 });
            RecvHook.ThreadACL.SetExclusiveACL(new Int32[] { 0 });

            Interface.IsInstalled(RemoteHooking.GetCurrentProcessId());
            dwProHwnd = OpenProcess(PROCESS_ALL_ACCESS, 0, RemoteHooking.GetCurrentProcessId());
            //EasyHook.RemoteHooking.WakeUpProcess();
            while (true) { Thread.Sleep(500); }

        }





        [DllImport("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern uint OpenProcess(uint dwDesiredAccess, int bInheritHandle, int dwProcessId);
        public const uint PROCESS_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFF);
        public const uint SYNCHRONIZE = 0x00100000;
        public const uint STANDARD_RIGHTS_REQUIRED = 0x000F0000;
        public uint dwProHwnd = 0;
        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        delegate int DRecv(IntPtr socket, IntPtr buffer, int length, int flags);

        [DllImport("WS2_32.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern int recv(IntPtr socket, IntPtr buffer, int length, int flags);

        [UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true)]
        delegate int DSend(IntPtr socket, IntPtr buffer, int length, int flags);

        [DllImport("WS2_32.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        static extern int send(IntPtr socket, IntPtr buffer, int length, int flags);
    }
}
