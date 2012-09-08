#region License
// Copyright © Pavel Fedarovich, 2010-2012
// 
// This file is part of AvalonWizard.
//  
// You may at your option receive a license to Avalon Wizard under 
// either the terms of the Apache License version 2.0 or 
// the GNU Lesser General Public License (LGPL) version 2.1 or any later version.
//  
// AvalonWizard is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
//  
// You may obtain a copy of the Apache License at [http://www.apache.org/licenses/LICENSE-2.0].
// You may obtain a copy of the LGPL at [http://www.gnu.org/licenses/].
#endregion

using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
