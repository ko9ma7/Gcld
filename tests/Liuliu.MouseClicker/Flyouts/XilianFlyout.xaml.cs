using GalaSoft.MvvmLight.Messaging;
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
            if (role == null)
            {
                MessageBox.Show("未选择模拟器！");
                return;
            }
            Function func = new Function();
            func.Name = "任务";

            TaskContext context = new TaskContext(role, func);
            TaskEngine engine = role.TaskEngine;

            List<TaskBase> tasks = new List<TaskBase>();
            engine.AutoLogin = null;
            engine.ChangeRole = null;
            context.Settings.StepName = "指定洗练";
            Dictionary<int, List<bool?>> dict = new Dictionary<int, List<bool?>>();
            dict.Add(0, new List<bool?>() { T1_1.IsChecked, T1_2.IsChecked, T1_3.IsChecked, T1_4.IsChecked, T1_5.IsChecked, T1_6.IsChecked });
            dict.Add(1, new List<bool?>() { T2_1.IsChecked, T2_2.IsChecked, T2_3.IsChecked, T2_4.IsChecked, T2_5.IsChecked, T2_6.IsChecked });
            dict.Add(2, new List<bool?>() { T3_1.IsChecked, T3_2.IsChecked, T3_3.IsChecked, T3_4.IsChecked, T3_5.IsChecked, T3_6.IsChecked });
            dict.Add(3, new List<bool?>() { T4_1.IsChecked, T4_2.IsChecked, T4_3.IsChecked, T4_4.IsChecked, T4_5.IsChecked, T4_6.IsChecked });
            dict.Add(4, new List<bool?>() { T5_1.IsChecked, T5_2.IsChecked, T5_3.IsChecked, T5_4.IsChecked, T5_5.IsChecked, T5_6.IsChecked });
            dict.Add(5, new List<bool?>() { T6_1.IsChecked, T6_2.IsChecked, T6_3.IsChecked, T6_4.IsChecked, T6_5.IsChecked, T6_6.IsChecked });
            dict.Add(6, new List<bool?>() { T7_1.IsChecked, T7_2.IsChecked, T7_3.IsChecked, T7_4.IsChecked, T7_5.IsChecked, T7_6.IsChecked });
            dict.Add(7, new List<bool?>() { T8_1.IsChecked, T8_2.IsChecked, T8_3.IsChecked, T8_4.IsChecked, T8_5.IsChecked, T8_6.IsChecked });
            dict.Add(8, new List<bool?>() { T9_1.IsChecked, T9_2.IsChecked, T9_3.IsChecked, T9_4.IsChecked, T9_5.IsChecked, T9_6.IsChecked });
            dict.Add(9, new List<bool?>() { T10_1.IsChecked, T10_2.IsChecked, T10_3.IsChecked, T10_4.IsChecked, T10_5.IsChecked, T10_6.IsChecked });
        
            context.Settings.EquipmentTypeDict =dict;
            tasks.Add(new SmallTool(context));
            role.TaskEngine.Start(tasks.ToArray());
        }

        private void btnReset_click(object sender, RoutedEventArgs e)
        {
            this.T1.IsChecked = true;
            this.T2.IsChecked = true;
            this.T3.IsChecked = true;
            this.T4.IsChecked = true;
            this.T5.IsChecked = true;
            this.T6.IsChecked = true;
            this.T7.IsChecked = true;
            this.T8.IsChecked = true;
            this.T9.IsChecked = true;
            this.T10.IsChecked = true;

            this.T1.IsChecked = false;
            this.T2.IsChecked = false;
            this.T3.IsChecked = false;
            this.T4.IsChecked = false;
            this.T5.IsChecked = false;
            this.T6.IsChecked = false;
            this.T7.IsChecked = false;
            this.T8.IsChecked = false;
            this.T9.IsChecked = false;
            this.T10.IsChecked = false;
        }

        private void btnStop_click(object sender, RoutedEventArgs e)
        {
            role.TaskEngine.Stop();
        }
    }
}
