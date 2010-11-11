using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace AvalonWizard
{
    /// <summary>
    /// Provides data for the <see cref="WizardPage.Commit" /> 
    /// and <see cref="WizardPage.Rollback" /> events.
    /// </summary>
    public class WizardPageConfirmEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="page">The wizard page that has raised the event.</param>
        internal WizardPageConfirmEventArgs(WizardPage page)
        {
            Cancel = false;
            Page = page;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this action is to be cancelled or allowed.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c> to allow. Default is <c>false</c>.</value>
        [DefaultValue(false)]
        public bool Cancel { get; set; }

        /// <summary>
        /// Gets the <see cref = "WizardPage" /> that has raised the event.
        /// </summary>
        /// <value>The wizard page.</value>
        public WizardPage Page { get; private set; }
    }
}
