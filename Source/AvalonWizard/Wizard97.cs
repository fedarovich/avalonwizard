using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace AvalonWizard
{
    public class Wizard97 : DependencyObject
    {
        #region [Subtitle]

        public static String GetSubtitle(DependencyObject obj)
        {
            return (String)obj.GetValue(SubtitleProperty);
        }

        public static void SetSubtitle(DependencyObject obj, String value)
        {
            obj.SetValue(SubtitleProperty, value);
        }

        public static readonly DependencyProperty SubtitleProperty =
            DependencyProperty.RegisterAttached("Subtitle", typeof(String), typeof(Wizard97), new UIPropertyMetadata(null));

        #endregion [Subtitle]

        #region [Icon]

        public static ImageSource GetIcon(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(IconProperty, value);
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(ImageSource), typeof(Wizard97), new UIPropertyMetadata(null));

        #endregion [Icon]
    }
}
