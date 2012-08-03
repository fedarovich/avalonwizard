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
