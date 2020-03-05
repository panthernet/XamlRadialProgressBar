using System;
using System.Windows.Data;

namespace XamlRadialProgressBar
{
    public class ProgressToAngleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var progress = (double)values[0];
            var bar = values[1] as System.Windows.Controls.ProgressBar;

            return 359.999 * (progress / (bar.Maximum - bar.Minimum));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
