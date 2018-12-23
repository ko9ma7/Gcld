﻿using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Liuliu.MouseClicker.Contexts;
using Liuliu.MouseClicker.Mvvm;
using Liuliu.ScriptEngine;
using OSharp.Utility.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Liuliu.MouseClicker.ViewModels
{
    public class MemHelperViewModel:ViewModelExBase
    {
        public MemHelperViewModel()
        {
            Offset = 4;
            Number = 500;
            DataTypes = new List<string>() { "整数型", "浮点型", "文本型" };
          
            InitDataList();
            Messenger.Default.Register<string>(this, Notifications.MemHelperViewModel,
              (str) =>
              {
                  switch (str)
                  {
                      case "UpdateProcess":
                          Processes = UpdateProcess("NoxVMH");
                          break;
                  }
              });

        }
        private void InitDataList()
        {
            if(DataList!=null)
                 DataList.Clear();
            DataList = new ObservableCollection<Data>();
            for (int i = 0; i < Number; i++)
            {
                DataList.Add(new Data() { Id=i+1 });
            }
        }

        public List<ProcessInfo> UpdateProcess(string filter)
        {
            Process[] ps = Process.GetProcesses();
            List<ProcessInfo> list = new List<ProcessInfo>();
            DmPlugin dm = SoftContext.DmSystem.Dm;
           
            foreach (var p in ps)
            {
                int hwnd=dm.FindWindowByProcessId(p.Id,"","");
                string title=dm.GetWindowTitle(dm.GetWindow(hwnd, 7));
                list.Add(new ProcessInfo(p, title));
            }
            if (filter == null || filter == "")
            {
                return list;
            }
            return list.Where(x => x.Process.ProcessName.Contains(filter)).ToList();

        }

        private ObservableCollection<Data> _dataList;
        public ObservableCollection<Data> DataList
        {
            get { return _dataList; }
            set { SetProperty(ref _dataList, value, () => DataList); }
        }
        private ProcessInfo _selectedProcess;
        public ProcessInfo SelectedProcess
        {
            get { return _selectedProcess; }
            set { SetProperty(ref _selectedProcess, value, () => SelectedProcess); }
        }

        private List<ProcessInfo> _processes;
        public List<ProcessInfo> Processes
        {
            get { return _processes; }
            set { SetProperty(ref _processes, value, () => Processes); }
        }
        private string _initialAddress;
        public string InitialAddress
        {
            get { return _initialAddress; }
            set { SetProperty(ref _initialAddress, value, () => InitialAddress); }
        }
        private int _offset;
        public int Offset
        {
            get { return _offset; }
            set { SetProperty(ref _offset, value, () => Offset); }
        }

        private int _number;
        public int Number
        {
            get { return _number; }
            set
            {
                SetProperty(ref _number, value, () => Number);
                InitDataList();
            }
        }

        private string _filterStr;
        public string FilterStr
        {
            get { return _filterStr; }
            set {
                SetProperty(ref _filterStr, value, () => FilterStr);
                Processes=UpdateProcess(value);
            }
        }

        private List<string> _dataTypes;
        public List<string> DataTypes
        {
            get { return _dataTypes; }
            set { SetProperty(ref _dataTypes, value, () => DataTypes); }
        }

        
        private int _writeDataIndex;
        public int SelectedWriteData
        {
            get { return _writeDataIndex; }
            set { SetProperty(ref _writeDataIndex, value, () => SelectedWriteData); }
        }


        public ICommand ReadDataCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Debug.WriteLine("对" + SelectedWriteData + "进行写入数据：");
                    Debug.WriteLine("读取数据");
                    DmPlugin dm = SoftContext.DmSystem.Dm;
                    dm.SetMemoryHwndAsProcessId(true);
                    Debug.WriteLine("选择的进程ID:" + SelectedProcess.Process.Id);
                    Debug.WriteLine("起始地址:" + InitialAddress);
                    Debug.WriteLine(dm.ReadInt(SelectedProcess.Process.Id, InitialAddress, 0));
                    int initAddress = AnyRadixConvert._16To10(InitialAddress);
                    int pid = SelectedProcess.Process.Id;
                    for (int i = 0; i < Number; i++)
                    {
                        DataList[i].Offset= AnyRadixConvert._10To16(i * 4);
                        switch (SelectedWriteData)
                        {
                            case 0:
                                DataList[i].MemData1.Address = AnyRadixConvert._10To16( initAddress+ (i * 4));
                                DataList[i].MemData1.Offset = AnyRadixConvert._10To16(i*4);
                                DataList[i].MemData1.Value = dm.ReadInt(pid, AnyRadixConvert._10To16(initAddress + (i * 4)), 0);
                                break;
                            case 1:
                                DataList[i].MemData2.Address = AnyRadixConvert._10To16(initAddress + (i * 4));
                                DataList[i].MemData2.Offset = AnyRadixConvert._10To16(i * 4);
                                DataList[i].MemData2.Value = dm.ReadInt(pid, AnyRadixConvert._10To16(initAddress + (i * 4)), 0);
                                break;
                            case 2:
                                DataList[i].MemData3.Address = AnyRadixConvert._10To16(initAddress + (i * 4));
                                DataList[i].MemData3.Offset = AnyRadixConvert._10To16(i * 4);
                                DataList[i].MemData3.Value = dm.ReadInt(pid, AnyRadixConvert._10To16(initAddress + (i * 4)), 0);
                                break;
                            case 3:
                                DataList[i].MemData4.Address = AnyRadixConvert._10To16(initAddress + (i * 4));
                                DataList[i].MemData4.Offset = AnyRadixConvert._10To16(i * 4);
                                DataList[i].MemData4.Value = dm.ReadInt(pid, AnyRadixConvert._10To16(initAddress + (i * 4)), 0);
                                break;
                            case 4:
                                DataList[i].MemData5.Address = AnyRadixConvert._10To16(initAddress + (i * 4));
                                DataList[i].MemData5.Offset = AnyRadixConvert._10To16(i * 4);
                                DataList[i].MemData5.Value = dm.ReadInt(pid, AnyRadixConvert._10To16(initAddress + (i * 4)), 0);
                                break;
                        }
                    }


                });
            }
        }

        /// <summary>
        /// <函数：Encode>
        /// 作用：将字符串内容转化为16进制数据编码，其逆过程是Decode
        /// 参数说明：
        /// strEncode 需要转化的原始字符串
        /// 转换的过程是直接把字符转换成Unicode字符,比如数字"3"-->0033,汉字"我"-->U+6211
        /// 函数decode的过程是encode的逆过程.
        /// </summary>
        /// <param name="strEncode"></param>
        /// <returns></returns>
        public string Encode(string strEncode)
        {
            string strReturn = "";//  存储转换后的编码
            foreach (short shortx in strEncode.ToCharArray())
            {
                strReturn += shortx.ToString("X4");
            }
            return strReturn;
        }


        /// <summary>
        /// <函数：Decode>
        /// 作用：将16进制数据编码转化为字符串，是Encode的逆过程
        /// </summary>
        /// <param name="strDecode"></param>
        /// <returns></returns>
        public string Decode(string strDecode)
        {
            string sResult = "";
            for (int i = 0; i < strDecode.Length / 4; i++)
            {
                sResult += (char)short.Parse(strDecode.Substring(i * 4, 4), global::System.Globalization.NumberStyles.HexNumber);
            }
            return sResult;
        }

        public ICommand ContrastDataCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Debug.WriteLine("对比数据");
                });
            }
        }
        public ICommand ClearDataCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Debug.WriteLine("清除数据");
                    string add = "04EEFF11";
                    Debug.WriteLine((Convert.ToInt32(add, 16)+Convert.ToInt32((4*10).ToString(),16)).ToString("X2"));
                });
            }
        }

    }
    public class ProcessInfo
    {
        public ProcessInfo(Process p,string title="")
        {
            if(title=="")
                Show= p.Id + " " + p.ProcessName;
            else
                Show = title+" "+p.Id + " " + p.ProcessName;
            Process = p;
        }
        public string Show { get; set; }
        public Process Process { get; set; }
    }
    public class Data:ViewModelExBase
    {
        public Data()
        {
            MemData1 = new MemData();
            MemData2 = new MemData();
            MemData3 = new MemData();
            MemData4 = new MemData();
            MemData5 = new MemData();
        }
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value, () => Id); }
        }
        private string _offset;
        public string Offset
        {
            get { return _offset; }
            set { SetProperty(ref _offset, value, () => Offset); }
        }
        private MemData _memData1;
        public MemData MemData1
        {
            get { return _memData1; }
            set { SetProperty(ref _memData1, value, () => MemData1); }
        }
        private MemData _memData2;
        public MemData MemData2
        {
            get { return _memData2; }
            set { SetProperty(ref _memData2, value, () => MemData2); }
        }
        private MemData _memData3;
        public MemData MemData3
        {
            get { return _memData3; }
            set { SetProperty(ref _memData3, value, () => MemData3); }
        }
        private MemData _memData4;
        public MemData MemData4
        {
            get { return _memData4; }
            set { SetProperty(ref _memData4, value, () => MemData4); }
        }
        private MemData _memData5;
        public MemData MemData5
        {
            get { return _memData5; }
            set { SetProperty(ref _memData5, value, () => MemData5); }
        }
    }
    public class MemData:ViewModelExBase
    {
        private string _offset;
        public string Offset
        {
            get { return _offset; }
            set { SetProperty(ref _offset, value, () => Offset); }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set { SetProperty(ref _address, value, () => Address); }
        }
        private object _value;
        public object Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value, () => Value); }
        }
    }


}
