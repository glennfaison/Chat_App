using ChatApp.Models.Csharp;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ChatApp.ValueConverters
{
    /// <summary>
    /// Converts left or right to visibility.
    /// If the messenge sender is App.ThisUser, then set the visibility of the 
    /// right aligned message to visible. 
    /// Collapsed, otherwise and vice versa.
    /// </summary>
    public class MesssageToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var message = value as Message;
            if (message == null)
                return null;

            if(parameter as string == "left")
            {
                if (message.Receiver.Equals(App.ThisUser))
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
            if(parameter as string == "right")
            {
                if (message.Sender.Equals(App.ThisUser))
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
