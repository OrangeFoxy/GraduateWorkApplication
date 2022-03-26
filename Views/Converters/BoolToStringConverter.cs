using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace GraduateWorkApplication.Views.Converters
{
    public class BoolToStringConverter : IValueConverter
    {
        // Вывод строки по параметру, если параметр отсутсвует, то возвращается да/нет
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = value is bool && (bool)value;

            string p;
            string[] words = { "Да", "Нет" };
            if (parameter != null)
            {
                p = parameter.ToString();
                words = p.Split('/', '|', '\\', ':', ';', ',');
            }
            string positive = words[0];
            string negative = words[1];

            return boolValue ? positive : negative;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
