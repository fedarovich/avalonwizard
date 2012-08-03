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

namespace AvalonWizard
{
    /// <summary>
    /// Defines the way to render Aero glow in header.
    /// </summary>
    public enum AeroGlowStyle
    {
        /// <summary>
        /// Do not render Aero glow.
        /// </summary>
        None = -1,

        /// <summary>
        /// Render Aero glow as blurred text.
        /// </summary>
        BlurredText = 0,

        /// <summary>
        /// Render Aero glow as blurred rectangle.
        /// </summary>
        BlurredRectangle = 1,

        /// <summary>
        /// Render Aero glow as text with outer glow. This option is not supported on .Net 4 or later.
        /// </summary>
        [Obsolete("Not supported on .Net 4 or later.")]
        GlowingText = 2,
    }
}
