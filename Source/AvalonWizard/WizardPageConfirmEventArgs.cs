using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace AvalonWizard
{
    /// <summary>
    /// Arguments supplied to the <see cref = "WizardPage" /> events.
    /// </summary>
    public class WizardPageConfirmEventArgs : RoutedEventArgs
    {
        internal WizardPageConfirmEventArgs(WizardPage page)
        {
            Cancel = false;
            Page = page;
        }

        /// <summary>
        ///   Gets or sets a value indicating whether this action is to be cancelled or allowed.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c> to allow. Default is <c>false</c>.</value>
        [DefaultValue(false)]
        public bool Cancel { get; set; }

        /// <summary>
        ///   Gets the <see cref = "WizardPage" /> that has raised the event.
        /// </summary>
        /// <value>The wizard page.</value>
        public WizardPage Page { get; private set; }
    }
}
