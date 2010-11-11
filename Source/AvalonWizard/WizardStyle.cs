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
