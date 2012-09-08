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

using System.ComponentModel;
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
