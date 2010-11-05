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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

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

            logWindow = new EventLogWindow();
            logWindow.Show();
        }

        private void LogWizardEvent(object sender, RoutedEventArgs e)
        {
            logWindow.AddLogItem("Sender: Wizard. Event: {0}.", e.RoutedEvent.Name);
        }

        private void LogPageEvent(object sender, WizardPageConfirmEventArgs e)
        {
            logWindow.AddLogItem("Sender: {0}. Event: {1}. Cancel: {2}.", 
                e.Page.Header, e.RoutedEvent.Name, e.Cancel);
        }

        private void LogPageInit(object sender, WizardPageInitEventArgs e)
        {
            logWindow.AddLogItem("Sender: {0}. Event: {1}. Previous Page: {2}.", 
                e.Page.Header, e.RoutedEvent.Name, e.PreviousPage.Header);
        }

        private readonly EventLogWindow logWindow;
    }
}
