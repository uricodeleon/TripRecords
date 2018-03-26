using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TripsRecord.ViewModel.Commands.Converter
{
    class DateTime : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //string timeAgo = string.Empty;
            DateTimeOffset dateTime = (DateTimeOffset)value;
            DateTimeOffset rightNow = DateTimeOffset.Now;
            var difference = rightNow - dateTime;

            if (difference.TotalDays > 1)
                return $"{dateTime:d}";
            else
            {
                if (difference.TotalSeconds < 60)
                    return $"{difference.TotalSeconds:0} second(s) ago.";
                if (difference.TotalMinutes < 60)
                    return $"{difference.TotalMinutes:0} minute(s) ago.";
                if (difference.TotalHours < 24)
                    return $"{difference.TotalHours:0} hours ago.";

                return "yesterday";
            }

            //return timeAgo;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTimeOffset.Now;
        }
    }
}
