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

        public void AddLogItem(String format, params Object[] args)
        {
            if (!String.IsNullOrEmpty(format))
            {
                eventsList.Items.Add(String.Format(format, args));
            }
        }


    }
}
