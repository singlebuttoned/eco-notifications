using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Avalonia.Markup.Xaml.Converters;
using Avalonia.Media;
using EcoNotifications.App.Core.Resources;

namespace EcoNotifications.App.Front.Common;

public class IconsConverter : IValueConverter
{
    public static readonly IconsConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Icon icon && targetType.IsAssignableTo(typeof(IImage)))
        {
            var assembly = typeof(IconsConverter).Assembly;
            var img = icon switch
            {
                Icon.AllEventsNavigatorItem => $"avares://{assembly}/Assets/icons/icon1.png",
                Icon.AllRequestsNavigatorItem => $"avares://{assembly}/Assets/icons/icon2.png",
                _ => throw new ArgumentOutOfRangeException(nameof(value), icon, null)
            };

            return new BitmapTypeConverter().ConvertFrom(null, culture, img);
        }

        // converter used for the wrong type
        return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}