﻿// -----------------------------------------------------------------------
//  <copyright file="OperationHelper.cs" company="柳柳软件">
//      Copyright (c) 2017 66SOFT. All rights reserved.
//  </copyright>
//  <site>http://www.66soft.net</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2017-12-16 0:23</last-date>
// -----------------------------------------------------------------------

using System;
using System.IO;

using Liuliu.ScriptEngine;

using OSharp.Utility.Data;
using Liuliu.ScriptEngine.Damo;

namespace Liuliu.MouseClicker.Contexts
{
    public static class OperationHelper
    {
        public static OperationResult<DmSystem> GetDmSystem(string dmPath = "dm.dll")
        {
            if (!File.Exists(dmPath))
            {
                return new OperationResult<DmSystem>(OperationResultType.Error, $"大漠插件文件“{dmPath}”不存在");
            }
            DmPlugin dm = new DmPlugin(dmPath);
            Version ver = new Version(dm.Ver());
            if (ver > new Version("3.1233"))
            {
                string code = SoftContext.Locator.Settings.DmRegCode;
                code = "rhjv5528a9fb08d84534868df99ad3940be57c";
                if (code == null)
                {
                    return new OperationResult<DmSystem>(OperationResultType.Error, "大漠插件版本大于“3.1233”，请在“菜单-设置”中设置大漠注册码");
                }
                //int ret = dm.Reg(code);
                int ret = dm.RegEx("rhjv5528a9fb08d84534868df99ad3940be57c", "1.0", "221.229.162.75|58.218.204.170|221.229.162.171|221.229.162.40");
                if (ret != 1)
                {
                    return new OperationResult<DmSystem>(OperationResultType.Error, $"大漠插件版本大于“3.1233”，执行插件注册失败，失败码：{ret}");
                }
            }
            DmSystem system = new DmSystem(dm);
            return new OperationResult<DmSystem>(OperationResultType.Success, "大漠系统对象获取成功", system);
        }
    }
}