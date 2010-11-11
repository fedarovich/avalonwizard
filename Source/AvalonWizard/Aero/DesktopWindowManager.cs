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
