#region Licence
// This file is part of AvalonWizard.
// 
// AvalonWizard is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 2.1 of the License, or
// (at your option) any later version.
// 
// AvalonWizard is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with AvalonWizard.  If not, see <http://www.gnu.org/licenses/>.
#endregion
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
