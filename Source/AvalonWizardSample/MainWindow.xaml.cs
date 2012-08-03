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
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AvalonWizard;

namespace AvalonWizardSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            logWindow = new EventLogWindow();

            InitializeComponent();

            cmbWizardStyle.Items.Add(WizardStyle.Aero);
            cmbWizardStyle.Items.Add(WizardStyle.Wizard97);
            cmbWizardStyle.Items.Add(WizardStyle.Auto);

            cmbAeroGlowStyle.Items.Add(AeroGlowStyle.None);
            cmbAeroGlowStyle.Items.Add(AeroGlowStyle.BlurredText);
            cmbAeroGlowStyle.Items.Add(AeroGlowStyle.BlurredRectangle);
            cmbAeroGlowStyle.Items.Add(AeroGlowStyle.GlowingText);

            wizard.Finished += LogWizardEvent;
            wizard.Cancelled += LogWizardEvent;
            wizard.CurrentPageChanged += LogWizardEvent;

            foreach (var page in wizard.Pages)
            {
                page.Commit += LogPageEvent;
                page.Rollback += LogPageEvent;
                page.Initialize += LogPageInit;
            }

            logWindow.Show();
        }

        private void LogWizardEvent(object sender, RoutedEventArgs e)
        {
            logWindow.AddLogItem(new EventLogItem
                                     {
                                         Sender = "Wizard",
                                         EventName = e.RoutedEvent.Name
                                     });
        }

        private void LogPageEvent(object sender, WizardPageConfirmEventArgs e)
        {
            logWindow.AddLogItem(new EventLogItem
                                     {
                                         Sender = e.Page != null ? e.Page.Header.ToString() : "null",
                                         EventName = e.RoutedEvent.Name,
                                         ParameterName = "Cancel",
                                         ParameterValue = e.Cancel.ToString()
                                     });
        }

        private void LogPageInit(object sender, WizardPageInitEventArgs e)
        {
            logWindow.AddLogItem(new EventLogItem
                                     {
                                         Sender = e.Page != null ? e.Page.Header.ToString() : "null",
                                         EventName = e.RoutedEvent.Name,
                                         ParameterName = "Previous Page",
                                         ParameterValue =
                                             e.PreviousPage != null ? e.PreviousPage.Header.ToString() : "null"
                                     });
        }

        private void OnNextPageChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = (ComboBox)sender;
            wizard.CurrentPage.NextPage = wizard.Pages.ElementAtOrDefault(combo.SelectedIndex + 3);
        }

        private readonly EventLogWindow logWindow;
    }
}
