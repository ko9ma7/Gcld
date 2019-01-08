using GalaSoft.MvvmLight.Messaging;
using Liuliu.MouseClicker.Contexts;
using Liuliu.MouseClicker.Models;
using Liuliu.MouseClicker.Tasks;
using Liuliu.MouseClicker.ViewModels;
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
    /// QuenchingFlyout.xaml 的交互逻辑
    /// </summary>
    public partial class QuenchingFlyout
    {
        public QuenchingFlyout()
        {
            InitializeComponent();
            RegisterMessengers();
            IsOpenChanged += async (sender, e) => await XilianFlyout_IsOpenChanged(sender, e);



        }
        Role _role = null;
        private void RegisterMessengers()
        {

            Messenger.Default.Register<SendData<Role>>(this, Notifications.XilianFlyout,
              sendData =>
              {
                  if (sendData.Message == "OpenXilianFlyout")
                  {
                      OpenXilianFlyout();
                      _role = sendData.Data;
                  }
              });

        }
        private async Task XilianFlyout_IsOpenChanged(object sender, RoutedEventArgs e)
        {
            if (IsOpen)
            {
                Reset();
                return;
            }
            //关闭窗口，传送数据
            //Dictionary<int, List<bool?>> dict = new Dictionary<int, List<bool?>>();
            //dict.Add(0, new List<bool?>() { T1_1.IsChecked, T1_2.IsChecked, T1_3.IsChecked, T1_4.IsChecked, T1_5.IsChecked, T1_6.IsChecked });
            //dict.Add(1, new List<bool?>() { T2_1.IsChecked, T2_2.IsChecked, T2_3.IsChecked, T2_4.IsChecked, T2_5.IsChecked, T2_6.IsChecked });
            //dict.Add(2, new List<bool?>() { T3_1.IsChecked, T3_2.IsChecked, T3_3.IsChecked, T3_4.IsChecked, T3_5.IsChecked, T3_6.IsChecked });
            //dict.Add(3, new List<bool?>() { T4_1.IsChecked, T4_2.IsChecked, T4_3.IsChecked, T4_4.IsChecked, T4_5.IsChecked, T4_6.IsChecked });
            //dict.Add(4, new List<bool?>() { T5_1.IsChecked, T5_2.IsChecked, T5_3.IsChecked, T5_4.IsChecked, T5_5.IsChecked, T5_6.IsChecked });
            //dict.Add(5, new List<bool?>() { T6_1.IsChecked, T6_2.IsChecked, T6_3.IsChecked, T6_4.IsChecked, T6_5.IsChecked, T6_6.IsChecked });
            //dict.Add(6, new List<bool?>() { T7_1.IsChecked, T7_2.IsChecked, T7_3.IsChecked, T7_4.IsChecked, T7_5.IsChecked, T7_6.IsChecked });
            //dict.Add(7, new List<bool?>() { T8_1.IsChecked, T8_2.IsChecked, T8_3.IsChecked, T8_4.IsChecked, T8_5.IsChecked, T8_6.IsChecked });
            //dict.Add(8, new List<bool?>() { T9_1.IsChecked, T9_2.IsChecked, T9_3.IsChecked, T9_4.IsChecked, T9_5.IsChecked, T9_6.IsChecked });
            //dict.Add(9, new List<bool?>() { T10_1.IsChecked, T10_2.IsChecked, T10_3.IsChecked, T10_4.IsChecked, T10_5.IsChecked, T10_6.IsChecked });
            //Messenger.Default.Send(new SendData<Dictionary<int, List<bool?>>>() { Message = "XilianMessage", Data = dict }, Notifications.MainCommandViewModel);
        }

        private void OpenXilianFlyout()
        {
            if (!IsOpen)
            {
                IsOpen = true;
            }
        }

        private void Reset()
        {
            QuenchingViewModel model = SoftContext.Locator.Quenching;
            model.TaozhuangList.ToList().ForEach(x => 
            {
                x.麒麟双枪.IsHave = false;
                x.麒麟.IsHave = false;
                x.三昧纯阳铠.IsHave = false;
                x.蝶凤舞阳.IsHave = false;
                x.伏龙帅印.IsHave = false;
                x.蟠龙华盖.IsHave = false;
            });
            SoftContext.Locator.Main.StatusBar = "套装初始化成功";
        }

        private void btnReset_click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void btnStop_click(object sender, RoutedEventArgs e)
        {
            Reset();
            QuenchingViewModel model = SoftContext.Locator.Quenching;
            List<Equips> equipsList = new List<Equips>();
            //初始化装备数据

            var rootObj = _role.GetData(Const.GET_EQUIPS_LIST,()=> { _role.Window.Dm.MoveToClick(459, 30); _role.Window.Dm.Delay(1000); });
            if (rootObj != null)
            {
                equipsList = rootObj.action.data.equips;
                foreach (var equip in equipsList)
                {
                    套装 taozhuang = model.TaozhuangList.FirstOrDefault(x =>equip.refreshAttribute.Count==4&&((Equipment)x.GetType().GetProperty(equip.name).GetValue(x)).类型.ToString() == equip.refreshAttribute[0].attrName && ((Equipment)x.GetType().GetProperty(equip.name).GetValue(x)).IsHave == false);
                    if (taozhuang != null)
                    {
                        ((Equipment)taozhuang.GetType().GetProperty(equip.name).GetValue(taozhuang)).IsHave = true;
                    }
                }
            }
           
           
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == null) return;
            var d = cb.DataContext;
           
            QuenchingViewModel model = SoftContext.Locator.Quenching;
            switch (cb.Content.ToString())
            {
                case "青龙":
                    model.TaozhuangList[0].麒麟双枪.IsHave = false;
                    model.TaozhuangList[0].麒麟.IsHave = false;
                    model.TaozhuangList[0].三昧纯阳铠.IsHave = false;
                    model.TaozhuangList[0].蝶凤舞阳.IsHave = false;
                    model.TaozhuangList[0].伏龙帅印.IsHave = false;
                    model.TaozhuangList[0].蟠龙华盖.IsHave = false;
                    break;
               


            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
