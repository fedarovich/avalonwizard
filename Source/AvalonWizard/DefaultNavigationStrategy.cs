using System;
using System.Linq;

namespace AvalonWizard
{
    public class DefaultNavigationStrategy : INavigationStrategy
    {
        #region Implementation of INavigationStrategy

        public WizardPage GetNextPage(Wizard wizard, WizardPage currentPage)
        {
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