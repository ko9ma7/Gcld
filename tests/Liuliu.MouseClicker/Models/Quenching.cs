using Liuliu.MouseClicker.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liuliu.MouseClicker.Models
{
    public class 套装名称 : ViewModelExBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value, () => Name); }
        }

        private int _rowNumber;
        public int RowNumber
        {
            get { return _rowNumber; }
            set { SetProperty(ref _rowNumber, value, () => RowNumber); }
        }
    }
       
    public class 套装
    {
        public 套装名称 套装名称 { get; set; }
        public Equipment 麒麟双枪 { get; set; }
        public Equipment 麒麟 { get; set; }
        public Equipment 三昧纯阳铠 { get; set; }
        public Equipment 蝶凤舞阳 { get; set; }
        public Equipment 伏龙帅印 { get; set; }
        public Equipment 蟠龙华盖 { get; set; }
    }
   public class Equipment: ViewModelExBase
    {
        private EquipmentAttrType _leixing;
        public EquipmentAttrType 类型
        {
            get { return _leixing; }
            set { SetProperty(ref _leixing, value, () => 类型); }
        }

        private bool _isHave;
        public bool IsHave
        {
            get { return _isHave; }
            set { SetProperty(ref _isHave, value, () => IsHave); }
        }

    }
    public enum EquipmentAttrType
    {
        未知类型 = -1,
        攻击,
        防御,
        掌控,
        血量,
        强防,
        强壮,
        强攻
    }
    public enum EquipmentType
    {
        未知类型 = -1,
        麒麟双枪,
        麒麟,
        三昧纯阳铠,
        蝶凤舞阳,
        伏龙帅印,
        蟠龙华盖
    }
}
