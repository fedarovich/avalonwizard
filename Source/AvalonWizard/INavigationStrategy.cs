using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvalonWizard
{
    /// <summary>
    /// Wizard's navigation strategy allows to implement the custom way to select the next page.
    /// </summary>
    public interface INavigationStrategy
    {
        /// <summary>
        /// Gets the next page to go.
        /// </summary>
        /// <param name="wizard">Wizard instance.</param>
        /// <returns>The next page.</returns>
        WizardPage GetNextPage(Wizard wizard);
    }
}
