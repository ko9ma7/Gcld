using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Contexts
{
    public class NetProcess
    {
        /// <summary>
        /// 获取TCP连接对象
        /// </summary>
        /// <param name="pTcpTable"></param>
        /// <param name="dwOutBufLen"></param>
        /// <param name="sort"></param>
        /// <param name="ipVersion"></param>
        /// <param name="tblClass"></param>
        /// <param name="reserved"></param>
        /// <returns></returns>
        [DllImport("iphlpapi.dll", SetLastError = true)]
        private static extern uint GetExtendedTcpTable(IntPtr pTcpTable, ref int dwOutBufLen, bool sort, int ipVersion, TCP_TABLE_CLASS tblClass, uint reserved = 0);

        /// <summary>
        ///获取TCP连接对象
        /// </summary>
        /// <returns></returns>
        public static TcpRow[] GetAllTcpConnections()
        {
            TcpRow[] tTable;
            int AF_INET = 2;    // IP_v4
            int buffSize = 0;
            uint ret = GetExtendedTcpTable(IntPtr.Zero, ref buffSize, true, AF_INET, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
            IntPtr buffTable = Marshal.AllocHGlobal(buffSize);
            try
            {
                ret = GetExtendedTcpTable(buffTable, ref buffSize, true, AF_INET, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
                if (ret != 0)
                {
                    return null;
                }
                TcpTable tab = (TcpTable)Marshal.PtrToStructure(buffTable, typeof(TcpTable));
                IntPtr rowPtr = (IntPtr)((long)buffTable + Marshal.SizeOf(tab.dwNumEntries));
                tTable = new TcpRow[tab.dwNumEntries];

                for (int i = 0; i < tab.dwNumEntries; i++)
                {
                    TcpRow tcpRow = (TcpRow)Marshal.PtrToStructure(rowPtr, typeof(TcpRow));
                    tTable[i] = tcpRow;
                    rowPtr = (IntPtr)((long)rowPtr + Marshal.SizeOf(tcpRow));   // next entry
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buffTable);
            }
            return tTable;
        }
        /// <summary>
        ///获取TCP连接对象
        /// </summary>
        /// <returns></returns>
        public static TcpRow[] GetTcpConnections(int processId)
        {
            TcpRow[] tTable;
            int AF_INET = 2;    // IP_v4
            int buffSize = 0;
            uint ret = GetExtendedTcpTable(IntPtr.Zero, ref buffSize, true, AF_INET, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
            IntPtr buffTable = Marshal.AllocHGlobal(buffSize);
            try
            {
                ret = GetExtendedTcpTable(buffTable, ref buffSize, true, AF_INET, TCP_TABLE_CLASS.TCP_TABLE_OWNER_PID_ALL);
                if (ret != 0)
                {
                    return null;
                }
                TcpTable tab = (TcpTable)Marshal.PtrToStructure(buffTable, typeof(TcpTable));
                IntPtr rowPtr = (IntPtr)((long)buffTable + Marshal.SizeOf(tab.dwNumEntries));
                tTable = new TcpRow[tab.dwNumEntries];

                for (int i = 0; i < tab.dwNumEntries; i++)
                {
                    TcpRow tcpRow = (TcpRow)Marshal.PtrToStructure(rowPtr, typeof(TcpRow));
                    tTable[i] = tcpRow;
                    rowPtr = (IntPtr)((long)rowPtr + Marshal.SizeOf(tcpRow));   // next entry
                }
            }
            finally
            {
                Marshal.FreeHGlobal(buffTable);
            }

            return tTable.Where(x=>x.owningPid==processId).ToArray();
        }


    }

    #region TCP返回的数据结构
    /// <summary>
    /// TCP表类型
    /// </summary>
    public enum TCP_TABLE_CLASS
    {
        TCP_TABLE_BASIC_LISTENER,
        TCP_TABLE_BASIC_CONNECTIONS,
        TCP_TABLE_BASIC_ALL,
        TCP_TABLE_OWNER_PID_LISTENER,
        TCP_TABLE_OWNER_PID_CONNECTIONS,
        TCP_TABLE_OWNER_PID_ALL,
        TCP_TABLE_OWNER_MODULE_LISTENER,
        TCP_TABLE_OWNER_MODULE_CONNECTIONS,
        TCP_TABLE_OWNER_MODULE_ALL
    }
    /// <summary> 
    /// TCP当前状态
    /// </summary> 
    public enum ConnectionState : int
    {
        /// <summary> All </summary> 
        All = 0,
        /// <summary> Closed </summary> 
        Closed = 1,
        /// <summary> Listen </summary> 
        Listen = 2,
        /// <summary> Syn_Sent </summary> 
        Syn_Sent = 3,
        /// <summary> Syn_Rcvd </summary> 
        Syn_Rcvd = 4,
        /// <summary> Established </summary> 
        Established = 5,
        /// <summary> Fin_Wait1 </summary> 
        Fin_Wait1 = 6,
        /// <summary> Fin_Wait2 </summary> 
        Fin_Wait2 = 7,
        /// <summary> Close_Wait </summary> 
        Close_Wait = 8,
        /// <summary> Closing </summary> 
        Closing = 9,
        /// <summary> Last_Ack </summary> 
        Last_Ack = 10,
        /// <summary> Time_Wait </summary> 
        Time_Wait = 11,
        /// <summary> Delete_TCB </summary> 
        Delete_TCB = 12
    }


    /// <summary>
    /// TCP列结构（行）
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TcpRow
    {
        // DWORD is System.UInt32 in C#
        public ConnectionState state;
        public uint localAddr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] localPort;
        public uint remoteAddr;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] remotePort;
        public int owningPid;
        public System.Net.IPAddress LocalAddress
        {
            get
            {
                return new System.Net.IPAddress(localAddr);
            }
        }
        public ushort LocalPort
        {
            get
            {
                return BitConverter.ToUInt16(
                new byte[2] { localPort[1], localPort[0] }, 0);
            }
        }
        public System.Net.IPAddress RemoteAddress
        {
            get
            {
                return new System.Net.IPAddress(remoteAddr);
            }
        }
        public ushort RemotePort
        {
            get
            {
                return BitConverter.ToUInt16(
                new byte[2] { remotePort[1], remotePort[0] }, 0);
            }
        }
    }

    /// <summary>
    /// TCP表结构
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TcpTable
    {
        public uint dwNumEntries;
        TcpRow table;
    }
    #endregion


}
