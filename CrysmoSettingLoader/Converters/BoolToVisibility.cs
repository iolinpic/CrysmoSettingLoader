using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CrysmoSettingLoader.Converters
{
    /// <summary>
    /// converter of bool value to Visibility
    /// </summary>
    public class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = (bool)value;
            if (data)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}