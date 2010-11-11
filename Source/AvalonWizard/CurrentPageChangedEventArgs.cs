using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace AvalonWizard
{
    /// <summary>
    /// Provides data for <see cref="Wizard.CurrentPageChanged"/> event.
    /// </summary>
    public class CurrentPageChangedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Creates the new instance.
        /// </summary>
        /// <param name="oldPage">The old page.</param>
        /// <param name="newPage">The new page.</param>
        public CurrentPageChangedEventArgs(WizardPage oldPage, WizardPage newPage)
        {
            this.OldPage = oldPage;
            this.NewPage = newPage;
        }

        /// <summary>
        /// Gets the old page.
        /// </summary>
        public WizardPage OldPage
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the new page.
        /// </summary>
        public WizardPage NewPage
        {
            get;
            private set;
        }
    }
}
