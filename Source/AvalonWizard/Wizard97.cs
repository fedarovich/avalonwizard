#region Licence
// This file is part of AvalonWizard.
// 
// AvalonWizard is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 2.1 of the License, or
// (at your option) any later version.
// 
// AvalonWizard is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with AvalonWizard.  If not, see <http://www.gnu.org/licenses/>.
#endregion
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
