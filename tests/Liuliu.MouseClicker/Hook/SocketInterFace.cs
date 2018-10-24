using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Hook
{
    public class SocketInterFace:MarshalByRefObject
    {
        public delegate void LogArgsHander(BufferStruct argsbuffer);
        public static event LogArgsHander logEvent;

        public void IsInstalled(Int32 InClientPID)
        {
            Console.WriteLine("FileMon has been installed in target {0}.\r\n", InClientPID);
        }

        public void OnRecv(byte[] RecvBuffer, int LoginIndex, int LoginIndexEx)
        {
            BufferStruct BufferArgs = new BufferStruct();
            BufferArgs.Buffer = RecvBuffer;
            BufferArgs.BufferSize = RecvBuffer.Length;
            BufferArgs.ObjectType = "recv";
            OnLog(BufferArgs);
        }

        public void OnSend(byte[] RecvBuffer, int LoginIndex, int LoginIndexEx)
        {
            BufferStruct BufferArgs = new BufferStruct();
            BufferArgs.Buffer = RecvBuffer;
            BufferArgs.BufferSize = RecvBuffer.Length;
            BufferArgs.ObjectType = "send";
            OnLog(BufferArgs);
        }

        public void OnLog(string BufferArgs) { Console.WriteLine(BufferArgs); }

        public void OnLog(BufferStruct buf)
        {
            if (logEvent != null)
            {
                logEvent(buf);
            }
        }

        public struct BufferStruct
        {
            /// <summary>
            /// Socket指针
            /// </summary>
            public IntPtr sockHander;
            /// <summary>
            /// 封包数据
            /// </summary>
            public byte[] Buffer;
            /// <summary>
            /// 封包大小
            /// </summary>
            public int BufferSize;
            /// <summary>
            /// 封包动态序列
            /// </summary>
            public int[] LoginIdent;
            /// <summary>
            /// send recv
            /// </summary>
            public string ObjectType;
        }
    }
}
