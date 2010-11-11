using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AvalonWizard.Aero
{
    /// <summary>
    /// Provides borders and background color for <see cref="WizardPage"/> when Aero Wizard style is set.
    /// </summary>
    public class AeroWizardPageChrome : ContentControl
    {
        static AeroWizardPageChrome()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AeroWizardPageChrome), new FrameworkPropertyMetadata(typeof(AeroWizardPageChrome)));
        }
    }
}
