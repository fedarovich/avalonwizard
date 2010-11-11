using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace AvalonWizard
{
    /// <summary>
    /// Provides data for the <see cref = "WizardPage.Initialize" /> event.
    /// </summary>
    public class WizardPageInitEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="page">
        /// The <see cref="WizardPage" /> that has raised the event.
        /// </param>
        /// <param name="previousPage">
        /// The <see cref="WizardPage" /> that was previously selected when the event was raised.
        /// </param>
        internal WizardPageInitEventArgs(WizardPage page, WizardPage previousPage)
        {
            Page = page;
            PreviousPage = previousPage;
        }

        /// <summary>
        /// Gets the <see cref="WizardPage" /> that has raised the event.
        /// </summary>
        /// <value>The wizard page.</value>
        public WizardPage Page { get; private set; }

        /// <summary>
        /// Gets the <see cref="WizardPage" /> that was previously selected when the event was raised.
        /// </summary>
        /// <value>The previous wizard page.</value>
        public WizardPage PreviousPage { get; private set; }
    }
}
