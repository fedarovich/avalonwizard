using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvalonWizard.Aero
{
    public static class DesktopWindowManager
    {
        public static bool IsCompositionEnabled
        {
            get
            {
                return isSupported && WinApi.DwmIsCompositionEnabled();
            }
        }

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
