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

namespace AvalonWizard.Aero
{
    /// <summary>
    /// Gets the information about Desktop Window Manager.
    /// </summary>
    public static class DesktopWindowManager
    {
        /// <summary>
        /// Gets the value indicating whether DWM composition is enabled.
        /// </summary>
        public static bool IsCompositionEnabled
        {
            get
            {
                return isSupported && WinApi.DwmIsCompositionEnabled();
            }
        }

        /// <summary>
        /// Gets the value indicating whether the Desktop Window Manager is available on the operating system.
        /// Returns <c>true</c> for Windows Vista and higher. 
        /// Returns <c>false</c> for Windows XP and Windows 2003 Server.
        /// </summary>
        public static bool IsSupported
        {
            get
            {
                return isSupported;
            }
        }

        internal static void ExtendFrameIntoClientArea(IntPtr hwnd, ref WinApi.Margins margins)
        {
            if (isSupported)
            {
                WinApi.DwmExtendFrameIntoClientArea(hwnd, ref margins);
            }
        }

        internal static void ResetGlass(IntPtr hwnd)
        {
            if (isSupported)
            {
                var margins = new WinApi.Margins(false);
                WinApi.DwmExtendFrameIntoClientArea(hwnd, ref margins);
            }
        }

        internal static void SetTitleAndIconVisibility(IntPtr hwnd, bool visible)
        {
            if (isSupported)
            {
                const WinApi.WTNCA mask = WinApi.WTNCA.NoDrawCaption | WinApi.WTNCA.NoDrawIcon | WinApi.WTNCA.NoSysMenu;
                var flags = visible ? default(WinApi.WTNCA) : mask;

                var options = new WinApi.WTA_OPTIONS { Flags = flags, Mask = mask };
                WinApi.SetWindowThemeAttribute(hwnd, WinApi.WINDOWTHEMEATTRIBUTETYPE.NonClient,
                    ref options, WinApi.WTA_OPTIONS.Size);
            }
        }

        private static readonly bool isSupported = Environment.OSVersion.Version.Major >= 6;
    }
}
