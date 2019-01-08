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
           
        }
        
        private ObservableCollection<套装> _taozhuangList;
        public ObservableCollection<套装> TaozhuangList
        {
            get { return _taozhuangList; }
            set { SetProperty(ref _taozhuangList, value, () => TaozhuangList); }
        }

    }
}
