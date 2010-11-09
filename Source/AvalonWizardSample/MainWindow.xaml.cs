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

            cmbNextPage.Items.Add(wizard.Pages[3]);
            cmbNextPage.Items.Add(wizard.Pages[4]);
            cmbNextPage.Items.Add(wizard.Pages[5]);

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

        private readonly EventLogWindow logWindow;
    }
}
