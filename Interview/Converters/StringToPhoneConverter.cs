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
    public class StringToPhoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            string phoneNo = value.ToString().Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty).Replace("-", string.Empty);

            switch (phoneNo.Length)
            {
                case 1:
                    return Regex.Replace(phoneNo, @"(\d{1})","+7$1");
                case 12:
                    return Regex.Replace(phoneNo, @"(?:\+7\D*)?([0-9]\d{2})\D*([0-9]\d{2})\D*(\d{2})\D*(\d{2})", "+7($1)-$2-$3-$4");
                default:
                    return phoneNo;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
