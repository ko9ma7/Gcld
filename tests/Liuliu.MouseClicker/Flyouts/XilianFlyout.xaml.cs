﻿using GalaSoft.MvvmLight.Messaging;
using Liuliu.MouseClicker.Tasks;
using Liuliu.ScriptEngine.Models;
using Liuliu.ScriptEngine.Tasks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Liuliu.MouseClicker.Flyouts
{
    /// <summary>
    /// XilianFlyout.xaml 的交互逻辑
    /// </summary>
    public partial class XilianFlyout
    {
        public XilianFlyout()
        {
            InitializeComponent();
            RegisterMessengers();
        }
        Role role = null;
        private void RegisterMessengers()
        {
            Messenger.Default.Register<Role>(this, "XilianFlyout",
                msg =>
               {
                   if(msg!=null)
                     OpenXilianFlyout();
                   role = msg;
               });

        }
        private void OpenXilianFlyout()
        {
            if (!IsOpen)
            {
                IsOpen = true;
            }
        }

        private void btnXilian_click(object sender, RoutedEventArgs e)
        {
            Function func = new Function();
            func.Name = "任务";

            TaskContext context = new TaskContext(role, func);
            TaskEngine engine = role.TaskEngine;

            List<TaskBase> tasks = new List<TaskBase>();

            //engine.AutoLogin = () => AutoLogin(context);
            engine.ChangeRole = () => role.ChangeRole();
            engine.AutoLogin = null;
            engine.ChangeRole = null;
            context.Settings.IsAutoClear2 = true;
            Dictionary<string, List<bool?>> dict = new Dictionary<string, List<bool?>>();
            dict.Add("青龙套装", new List<bool?>() { T1_1.IsChecked, T1_2.IsChecked, T1_3.IsChecked, T1_4.IsChecked, T1_5.IsChecked, T1_6.IsChecked });
            dict.Add("白虎套装", new List<bool?>() { T2_1.IsChecked, T2_2.IsChecked, T2_3.IsChecked, T2_4.IsChecked, T2_5.IsChecked, T2_6.IsChecked });
            dict.Add("朱雀套装", new List<bool?>() { T3_1.IsChecked, T3_2.IsChecked, T3_3.IsChecked, T3_4.IsChecked, T3_5.IsChecked, T3_6.IsChecked });
            dict.Add("鲮鲤套装", new List<bool?>() { T4_1.IsChecked, T4_2.IsChecked, T4_3.IsChecked, T4_4.IsChecked, T4_5.IsChecked, T4_6.IsChecked });
            dict.Add("玄武套装", new List<bool?>() { T5_1.IsChecked, T5_2.IsChecked, T5_3.IsChecked, T5_4.IsChecked, T5_5.IsChecked, T5_6.IsChecked });
            dict.Add("霸下套装", new List<bool?>() { T6_1.IsChecked, T6_2.IsChecked, T6_3.IsChecked, T6_4.IsChecked, T6_5.IsChecked, T6_6.IsChecked });
            dict.Add("驱虎套装", new List<bool?>() { T7_1.IsChecked, T7_2.IsChecked, T7_3.IsChecked, T7_4.IsChecked, T7_5.IsChecked, T7_6.IsChecked });
            dict.Add("烛龙套装", new List<bool?>() { T8_1.IsChecked, T8_2.IsChecked, T8_3.IsChecked, T8_4.IsChecked, T8_5.IsChecked, T8_6.IsChecked });
            dict.Add("凤凰套装", new List<bool?>() { T9_1.IsChecked, T9_2.IsChecked, T9_3.IsChecked, T9_4.IsChecked, T9_5.IsChecked, T9_6.IsChecked });
            dict.Add("灵龟套装", new List<bool?>() { T10_1.IsChecked, T10_2.IsChecked, T10_3.IsChecked, T10_4.IsChecked, T10_5.IsChecked, T10_6.IsChecked });
        
            context.Settings.EquipmentTypeDict =dict;
            tasks.Add(new SmallTool(context));
            role.TaskEngine.Start(tasks.ToArray());
        }

        private void btnReset_click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStop_click(object sender, RoutedEventArgs e)
        {
            role.TaskEngine.Stop();
        }
    }
}
