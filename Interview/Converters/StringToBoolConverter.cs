using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Interview
{
    class StringToBoolConverter : IMultiValueConverter
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+");
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool res = false;
            for (int i = 0; i < values.Length; i++)
            {
                if (i<2)
                {
                    res = IsValid(values[i].ToString());
                }
                else
                {
                    res = IsNumberValid(values[i].ToString());
                }
                
            }
            return res;
        }
        
        private bool IsValid(string value)
        {
            if (value.Length>2 && value.Length<50)
            {
                return true;
            }
            return false;
        }
        private bool IsNumberValid(string value)
        {
            string comparer=value.Replace("+", string.Empty).Replace("-",string.Empty).Replace("(",string.Empty).Replace(")",string.Empty);
            if (comparer.Length==11 && !_regex.IsMatch(comparer))
            {
                return true;
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
