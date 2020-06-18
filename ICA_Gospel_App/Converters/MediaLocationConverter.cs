using System;
using System.Globalization;
using Xamarin.Forms;

namespace ICA_Gospel_App
{
    public class MediaLocationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (string.IsNullOrWhiteSpace(value.ToString()))
                return null;

            if (Device.RuntimePlatform == Device.UWP)
                return new Uri($"ms-appx:///Resources/Video/{value}");
            else
                return new Uri($"ms-appx:///{value}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
