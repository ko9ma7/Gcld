// -----------------------------------------------------------------------
//  <copyright file="MainCommandViewModel.cs" company="柳柳软件">
//      Copyright (c) 2017 66SOFT. All rights reserved.
//  </copyright>
//  <site>http://www.66soft.net</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2017-12-15 23:31</last-date>
// -----------------------------------------------------------------------

using System.Windows.Input;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using Liuliu.MouseClicker.Mvvm;
using System.Diagnostics;
using Liuliu.ScriptEngine.Tasks;
using Liuliu.MouseClicker.Tasks;
using Liuliu.ScriptEngine.Models;

namespace Liuliu.MouseClicker.ViewModels
{
    public class MainCommandViewModel : ViewModelExBase
    {
        public ICommand OpenSettingsFlyoutCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send("OpenSettingsFlyout", "SettingsFlyout");
                });
            }
        }

        public ICommand OpenRoleSettingFlyoutCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send("OpenRoleSettingFlyout", "RoleSettingFlyout");
                    TaskEngine engine = new TaskEngine();
                    IRole role = new Role();
                    Function func = new Function();
                    
                    TaskContext context = new TaskContext(role,func);
                    engine.Start(new CaochuanjiejianTask(context));
                });
            }
        }
    }
}