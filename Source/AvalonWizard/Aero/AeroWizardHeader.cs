using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AvalonWizard.Extensions;

namespace AvalonWizard.Aero
{
    public class AeroWizardHeader : Control
    {
        public AeroWizardHeader()
        {
            Loaded += OnLoaded;
        }

        static AeroWizardHeader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AeroWizardHeader), new FrameworkPropertyMetadata(typeof(AeroWizardHeader)));
        }

        #region [IsCompositionEnabled]

        public bool IsCompositionEnabled
        {
            get { return (bool)GetValue(IsCompositionEnabledProperty); }
            private set { SetValue(IsCompositionEnabledPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey IsCompositionEnabledPropertyKey =
            DependencyProperty.RegisterReadOnly("IsCompositionEnabled", typeof(bool), typeof(AeroWizardHeader),
                                                new UIPropertyMetadata(true));

        public static readonly DependencyProperty IsCompositionEnabledProperty =
            IsCompositionEnabledPropertyKey.DependencyProperty;       

        #endregion [IsCompositionEnabled]

        #region [IsActive]

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            private set { SetValue(IsActivePropertyKey, value); }
        }

        private static readonly DependencyPropertyKey IsActivePropertyKey =
            DependencyProperty.RegisterReadOnly("IsActive", typeof (bool), typeof (AeroWizardHeader),
                                                new UIPropertyMetadata(true));

        public static readonly DependencyProperty IsActiveProperty =
            IsActivePropertyKey.DependencyProperty;

        #endregion [IsActive]

        #region [Private Members]

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (ParentWindow != null)
            {
                HwndSource.AddHook(WndProc);

                DependencyPropertyDescriptor isActiveDesc = DependencyPropertyDescriptor.FromProperty(
                    Window.IsActiveProperty, typeof(Window));
                isActiveDesc.AddValueChanged(window, OnWindowActiveChanged);
            }

            SetGlass();
        }

        private void OnWindowActiveChanged(object sender, EventArgs e)
        {
            IsActive = ParentWindow.IsActive;
        }

        private void SetGlass()
        {
            IsCompositionEnabled = WinApi.DwmIsCompositionEnabled();
            if (IsCompositionEnabled && window != null)
            {
                HwndSource.CompositionTarget.BackgroundColor = Colors.Transparent;

                // Create a margin structure
                var margins = new WinApi.Margins
                {
                    Left = 0,
                    Right = 0,
                    Top = (int)this.ActualHeight,
                    Bottom = 0
                };

                WinApi.DwmExtendFrameIntoClientArea(HwndSource.Handle, ref margins);               
            }
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            if (msg.In(WinApi.WM_DWMCOMPOSITIONCHANGED, WinApi.WM_DWMNCRENDERINGCHANGED))
            {
                IsCompositionEnabled = WinApi.DwmIsCompositionEnabled();
                if (IsCompositionEnabled)
                {
                    SetGlass();
                }
                handled = true;
            }
            return IntPtr.Zero;
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            if (ParentWindow != null)
            {
                ParentWindow.DragMove();
            }
        }

        private Window ParentWindow
        {
            get
            {
                return window ?? (window = Window.GetWindow(this));
            }
        }

        private HwndSource HwndSource
        {
            get
            {
                return hwndSource ?? (hwndSource = PresentationSource.FromVisual(ParentWindow) as HwndSource);
            }
        }

        private Window window;

        private HwndSource hwndSource;

        #endregion [Private Members]
    }
}
