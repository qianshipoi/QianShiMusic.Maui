﻿using System.Globalization;

namespace QianShiMusic.Converters
{
    internal class LongToTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is long val)
            {
                var timeSpan = TimeSpan.FromMilliseconds(val);
                return timeSpan;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
