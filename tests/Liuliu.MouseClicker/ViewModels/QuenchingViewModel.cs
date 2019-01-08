using Liuliu.MouseClicker.Models;
using Liuliu.MouseClicker.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.ViewModels
{
    public class QuenchingViewModel : ViewModelExBase
    {
        public QuenchingViewModel()
        {
            套装 青龙套装 = new 套装() {套装名称=new 套装名称() { Name="青龙"},麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.血量 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.血量 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.血量 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.血量 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.血量 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.血量 } };
            套装 白虎套装 = new 套装() { 套装名称 = new 套装名称() { Name = "白虎" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.攻击 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.攻击 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.强攻 } };
            套装 朱雀套装 = new 套装() { 套装名称 = new 套装名称() { Name = "朱雀" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.攻击 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.攻击 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.强壮 } };
            套装 鲮鲤套装 = new 套装() { 套装名称 = new 套装名称() { Name = "鲮鲤" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.强防 } };
            套装 玄武套装 = new 套装() { 套装名称 = new 套装名称() { Name = "玄武" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.防御 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.防御 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.防御 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.防御 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.防御 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.防御 } };
            套装 霸下套装 = new 套装() { 套装名称 = new 套装名称() { Name = "霸下" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.掌控 } };
            套装 驱虎套装 = new 套装() { 套装名称 = new 套装名称() { Name = "驱虎" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.强攻 } };
            套装 烛龙套装 = new 套装() { 套装名称 = new 套装名称() { Name = "烛龙" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.强防 } };
            套装 凤凰套装 = new 套装() { 套装名称 = new 套装名称() { Name = "凤凰" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强壮 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.强攻 } };
            套装 灵龟套装 = new 套装() { 套装名称 = new 套装名称() { Name = "灵龟" }, 麒麟双枪 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 麒麟 = new Equipment() { 类型 = EquipmentAttrType.强攻 }, 三昧纯阳铠 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 蝶凤舞阳 = new Equipment() { 类型 = EquipmentAttrType.强防 }, 伏龙帅印 = new Equipment() { 类型 = EquipmentAttrType.掌控 }, 蟠龙华盖 = new Equipment() { 类型 = EquipmentAttrType.掌控 } };
            _taozhuangList = new ObservableCollection<套装>() { 青龙套装, 白虎套装, 朱雀套装, 鲮鲤套装, 玄武套装, 霸下套装, 驱虎套装, 烛龙套装, 凤凰套装, 灵龟套装 };
        }
        
        private ObservableCollection<套装> _taozhuangList;
        public ObservableCollection<套装> TaozhuangList
        {
            get { return _taozhuangList; }
            set { SetProperty(ref _taozhuangList, value, () => TaozhuangList); }
        }

    }
}
