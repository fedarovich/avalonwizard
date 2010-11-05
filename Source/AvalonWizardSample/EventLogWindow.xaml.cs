using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AvalonWizardSample
{
    /// <summary>
    /// Interaction logic for EventLogWindow.xaml
    /// </summary>
    public partial class EventLogWindow : Window
    {
        public EventLogWindow()
        {           
            InitializeComponent();
        }

        public void AddLogItem(EventLogItem logItem)
        {
            if (logItem != null)
            {
                eventsList.Items.Add(logItem);
            }
        }
    }
}
