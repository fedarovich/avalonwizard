using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvalonWizard
{
    public interface INavigationStrategy
    {
        WizardPage GetNextPage(Wizard wizard, WizardPage currentPage);
    }
}
