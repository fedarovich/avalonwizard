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

namespace AvalonWizard
{
    /// <summary>
    /// Represents a wizard style.
    /// </summary>
    public enum WizardStyle
    {
        /// <summary>
        /// <para>The style is automatically selected based on the OS version.</para>
        /// <list type="bullet">
        ///     <item>
        ///         <term><see cref="WizardStyle.Wizard97"/></term>
        ///         <description> is selected for Windows XP and Windows 2003 Server.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="WizardStyle.Aero"/></term>
        ///         <description> is selected for Windows Vista or higher.</description>
        ///     </item>
        /// </list>
        /// </summary>
        Auto,
        
        /// <summary>
        /// Wizard 97 style.
        /// </summary>
        Wizard97,
        
        /// <summary>
        /// Aero Wizard style.
        /// </summary>
        Aero
    }
}
