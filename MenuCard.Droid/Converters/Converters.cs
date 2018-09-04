using MvvmCross.Converters;
using System;
using System.Globalization;

namespace MenuCard.Droid.Converters
{
    public class GetMenuIconConverter : MvxValueConverter<string, int>
    {
        protected override int Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case "ic_accessibility_white_48dp":
                    return Resource.Drawable.ic_accessibility_white_48dp;
                case "ic_account_box_white_48dp":
                    return Resource.Drawable.ic_account_box_white_48dp;
                case "ic_android_white_48dp":
                    return Resource.Drawable.ic_android_white_48dp;
            }
            return 0;
        }
    }
}