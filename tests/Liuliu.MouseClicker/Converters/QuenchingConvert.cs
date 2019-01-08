using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Liuliu.MouseClicker.Converters
{
    /// <summary> 根据参考值范围确定状态 </summary>
    [ValueConversion(typeof(string), typeof(string))]
    public class QuenchingConvert : IMultiValueConverter
    {
   
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null) return false;

            if (values[0] == null) return false;

            if (values.Length != 2) return false;

            if ((bool)values[1] == true)
            {
                return true;
            }
            else
            {
                return values[0];
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    
}
