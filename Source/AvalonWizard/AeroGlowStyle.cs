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
