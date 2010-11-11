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
using System.Linq;

namespace AvalonWizard
{
    /// <summary>
    /// <para>The default implementation of <see cref="INavigationStrategy"/>.</para>
    /// <para>
    /// This implementation uses the <see cref="WizardPage.NextPage"/> property of the <see cref="Wizard.CurrentPage"/> 
    /// as the next page. If the value of the property is <c>null</c> it uses the next page 
    /// in the <see cref="Wizard.Pages"/> collection.
    /// </para>
    /// </summary>
    public class DefaultNavigationStrategy : INavigationStrategy
    {
        #region Implementation of INavigationStrategy

        /// <summary>
        /// Gets the next page.
        /// </summary>
        /// <param name="wizard">Wizard instance.</param>
        /// <returns>The next page.</returns>
        /// <remarks>
        /// This implementation uses the <see cref="WizardPage.NextPage"/> property of the <see cref="Wizard.CurrentPage"/> 
        /// as the next page. If the value of the property is <c>null</c> it uses the next page 
        /// in the <see cref="Wizard.Pages"/> collection.
        /// </remarks>
        public WizardPage GetNextPage(Wizard wizard)
        {
            var currentPage = wizard.CurrentPage;
            if (currentPage == null)
            {
                return wizard.Pages.Any() ? wizard.Pages.First() : null;
            }

            if (currentPage.NextPage != null)
            {
                return currentPage.NextPage;
            }

            return wizard.Pages.ElementAtOrDefault(wizard.Pages.IndexOf(currentPage) + 1);
        }

        #endregion
    }
}