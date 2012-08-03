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
using System.Windows;

namespace AvalonWizard
{
    /// <summary>
    /// A helper class providing attached properties for Aero Wizard style.
    /// </summary>
    public class AeroWizard : DependencyObject
    {
        #region [GlowStyle]

        /// <summary>
        /// Gets the Aero glow style of window header.
        /// </summary>
        public static AeroGlowStyle GetGlowStyle(DependencyObject obj)
        {
            return (AeroGlowStyle)obj.GetValue(GlowStyleProperty);
        }

        /// <summary>
        /// Sets the Aero glow style of window header.
        /// </summary>
        public static void SetGlowStyle(DependencyObject obj, AeroGlowStyle value)
        {
            obj.SetValue(GlowStyleProperty, value);
        }

        /// <summary>
        /// Identifies GlowStyle attached property.
        /// </summary>
        public static readonly DependencyProperty GlowStyleProperty = DependencyProperty.RegisterAttached(
            "GlowStyle", typeof(AeroGlowStyle), typeof(AeroWizard), new UIPropertyMetadata(AeroGlowStyle.BlurredText));

        #endregion
    }
}
