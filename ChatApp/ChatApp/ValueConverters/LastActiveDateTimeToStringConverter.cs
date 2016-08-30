using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ChatApp.ValueConverters
{
    /// <summary>
    /// Converts last active datetime to string
    /// </summary>
    public class LastActiveDateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var dateTime = value as DateTime?;
            if (dateTime == null)
                return "Active now";

            //logic to get last active time
            return "active 18h ago";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
