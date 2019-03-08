using GalaSoft.MvvmLight.Messaging;
using Liuliu.MouseClicker.Contexts;
using Liuliu.MouseClicker.Models;
using Liuliu.MouseClicker.Tasks;
using Liuliu.MouseClicker.ViewModels;
using Liuliu.ScriptEngine.Models;
using Liuliu.ScriptEngine.Tasks;
using Newtonsoft.Json.Linq;
using OSharp.Utility.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                      QuenchingViewModel model = SoftContext.Locator.Quenching;
                      model.TaozhuangList = new ObservableCollection<套装>(_role.TaozhuangList);
                      this.isSkip.IsChecked = _role.IsSkipIfOne;
                      this.gb.Header = "洗练助手--" + _role.WindowTitle;
                      SoftContext.Locator.Main.StatusBar = "套装初始化成功";
                  }
              });

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
                x.套装名称.IsHave = false;
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
            //var list = _role.GameHelper.GetWorkerStatic();
            //foreach (var item in list)
            //{
            //    Debug.WriteLine(item.lv + " " + item.name);
            //}
            //return;
            QuenchingViewModel model = SoftContext.Locator.Quenching;
            List<Equips> equipsList = new List<Equips>();
            //初始化装备数据

            var rootObj = _role.GameHelper.GetData(Const.GET_EQUIPS_LIST);
            if (rootObj != null)
            {
                JArray equips = rootObj.action.data.equips;
                if (equips != null)
                {
                    equipsList = JsonHelper.FromJson<List<Equips>>(equips.ToString());
                }
                else
                {
                    return;
                }
                foreach (var equip in equipsList)
                {
                    套装 taozhuang = model.TaozhuangList.FirstOrDefault(x => equip.refreshAttribute.Count == 4 && ((Equipment)x.GetType().GetProperty(equip.name).GetValue(x)).类型.ToString() == equip.refreshAttribute[0].attrName && ((Equipment)x.GetType().GetProperty(equip.name).GetValue(x)).IsHave == false);
                    if (taozhuang != null)
                    {
                        ((Equipment)taozhuang.GetType().GetProperty(equip.name).GetValue(taozhuang)).IsHave = true;
                        equip.IsBelong = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("获取数据失败!请点击洗练.");
                return;
            }
            int i = 1;
            foreach (var equip in equipsList)
            {

                if (equip.IsBelong == false && equip.refreshAttribute.Count == 4)
                {
                    Debug.WriteLine(i+" "+equip.name + " " + equip.refreshAttribute[0].attrName);
                }
                i++;
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == null) return;
            套装 taozhuang = cb.DataContext as 套装;
            QuenchingViewModel model = SoftContext.Locator.Quenching;

            int index = model.TaozhuangList.IndexOf(taozhuang);
            if(index>=0)
            {
                var t = model.TaozhuangList[index];
                t.麒麟双枪.IsHave = true;
                t.麒麟.IsHave = true;
                t.三昧纯阳铠.IsHave = true;
                t.蝶凤舞阳.IsHave = true;
                t.伏龙帅印.IsHave = true;
                t.蟠龙华盖.IsHave = true;
            }
            
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb == null) return;
            套装 taozhuang = cb.DataContext as 套装;
            QuenchingViewModel model = SoftContext.Locator.Quenching;

            int index = model.TaozhuangList.IndexOf(taozhuang);
            if (index >= 0)
            {
                var t = model.TaozhuangList[index];
                t.麒麟双枪.IsHave = false;
                t.麒麟.IsHave = false;
                t.三昧纯阳铠.IsHave = false;
                t.蝶凤舞阳.IsHave = false;
                t.伏龙帅印.IsHave = false;
                t.蟠龙华盖.IsHave = false;
            }
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            this._role.IsSkipIfOne = (bool)this.isSkip.IsChecked;
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            this._role.IsSkipIfOne = (bool)this.isSkip.IsChecked;
        }
    }
}
