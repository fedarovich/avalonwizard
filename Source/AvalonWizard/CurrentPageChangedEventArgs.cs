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
