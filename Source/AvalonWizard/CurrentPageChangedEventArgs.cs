using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace AvalonWizard
{
    public class CurrentPageChangedEventArgs : RoutedEventArgs
    {
        public CurrentPageChangedEventArgs(WizardPage oldPage, WizardPage newPage)
        {
            this.OldPage = oldPage;
            this.NewPage = newPage;
        }

        public WizardPage OldPage
        {
            get;
            private set;
        }

        public WizardPage NewPage
        {
            get;
            private set;
        }
    }
}
