using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace AvalonWizard
{
    /// <summary>
    /// A helper class providing attached properties for Wizard 97 style.
    /// </summary>
    public class Wizard97 : DependencyObject
    {
        #region [Subtitle]

        /// <summary>
        /// Gets the <see cref="WizardPage"/> subtitle.
        /// </summary>
        public static String GetSubtitle(DependencyObject obj)
        {
            return (String)obj.GetValue(SubtitleProperty);
        }

        /// <summary>
        /// Sets the <see cref="WizardPage"/> subtitle.
        /// </summary>
        public static void SetSubtitle(DependencyObject obj, String value)
        {
            obj.SetValue(SubtitleProperty, value);
        }

        /// <summary>
        /// Identifies Subtitle attached property.
        /// </summary>
        /// <seealso cref="GetSubtitle"/>
        /// <seealso cref="SetSubtitle"/>
        public static readonly DependencyProperty SubtitleProperty =
            DependencyProperty.RegisterAttached("Subtitle", typeof(String), typeof(Wizard97), new UIPropertyMetadata(null));

        #endregion [Subtitle]

        #region [Icon]

        /// <summary>
        /// Gets the <see cref="WizardPage"/> icon.
        /// </summary>
        public static ImageSource GetIcon(DependencyObject obj)
        {
            return (ImageSource)obj.GetValue(IconProperty);
        }

        /// <summary>
        /// Sets the <see cref="WizardPage"/> icon.
        /// </summary>
        /// <remarks>The icon dimensions must be 48x48.</remarks>
        public static void SetIcon(DependencyObject obj, ImageSource value)
        {
            obj.SetValue(IconProperty, value);
        }

        /// <summary>
        /// Identifies Subtitle attached property.
        /// </summary>
        /// <seealso cref="GetIcon"/>
        /// <seealso cref="SetIcon"/>
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(ImageSource), typeof(Wizard97), new UIPropertyMetadata(null));

        #endregion [Icon]
    }
}
