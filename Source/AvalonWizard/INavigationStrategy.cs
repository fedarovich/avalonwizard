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
