using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace AvalonWizard
{
    public static class WizardCommands
    {
        private static readonly ICommand nextPageCommand = new RoutedUICommand();

        private static readonly ICommand previousPageCommand = new RoutedUICommand();

        private static readonly ICommand finishCommand = new RoutedUICommand();

        private static readonly ICommand cancelCommand = new RoutedUICommand();

        public static ICommand NextPage
        {
            get
            {
                return nextPageCommand;
            }
        }

        public static ICommand PreviousPage
        {
            get
            {
                return previousPageCommand;
            }
        }

        public static ICommand Finish
        {
            get
            {
                return finishCommand;
            }
        }

        public static ICommand Cancel
        {
            get
            {
                return cancelCommand;
            }
        }
    }
}
