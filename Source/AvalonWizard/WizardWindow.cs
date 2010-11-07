using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interop;
using AvalonWizard.Aero;

namespace AvalonWizard
{
    public class WizardWindow : Window
    {
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            var hwnd = new WindowInteropHelper(this).Handle;

            var values = WinApi.WTNCA.NoDrawCaption | WinApi.WTNCA.NoDrawIcon;
            var options = new WinApi.WTA_OPTIONS { Flags = values, Mask = values };
            WinApi.SetWindowThemeAttribute(hwnd, WinApi.WINDOWTHEMEATTRIBUTETYPE.NonClient,
                ref options, WinApi.WTA_OPTIONS.Size);

            int exStyle = WinApi.GetWindowLong(hwnd, WinApi.GWL.ExStyle);
            WinApi.SetWindowLong(hwnd, WinApi.GWL.ExStyle, exStyle | WinApi.WS_EX_DLGMODALFRAME);

            WinApi.SetWindowPos(hwnd, IntPtr.Zero, 0, 0, 0, 0,
                                WinApi.SetWindowPosFlags.IgnoreMove | WinApi.SetWindowPosFlags.IgnoreResize |
                                WinApi.SetWindowPosFlags.IgnoreZOrder | WinApi.SetWindowPosFlags.FrameChanged);
        }
    }
}
