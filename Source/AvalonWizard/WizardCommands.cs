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
using System.Windows.Input;

namespace AvalonWizard
{
    /// <summary>
    /// Contains commands for the <see cref="Wizard"/> control.
    /// </summary>
    public static class WizardCommands
    {
        private static readonly ICommand nextPageCommand = new RoutedUICommand();

        private static readonly ICommand previousPageCommand = new RoutedUICommand();

        private static readonly ICommand finishCommand = new RoutedUICommand();

        private static readonly ICommand cancelCommand = new RoutedUICommand();

        /// <summary>
        /// Makes the wizard go to the next page.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Is the command parameter is <c>null</c>, the wizard navigates to next page in <see cref="Wizard.Pages"/> collection
        /// or finishes the wizard if the current page is the last one.
        /// </para>
        /// <para>
        /// The command parameter may be one of the following types:
        /// </para>
        /// <list type="table">
        ///     <listheader>
        ///         <term>Type</term>
        ///         <description>Usage</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="WizardPage"/></term>
        ///         <description>Navigates to the specified page.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="String"/></term>
        ///         <description>Navigates to the page with the specified name.</description>
        ///     </item>
        ///     <item>
        ///         <term>Any type convertible to <see cref="Int32"/></term>
        ///         <description>Navigates to the page with the specified index in the <see cref="Wizard.Pages"/> collection.</description>
        ///     </item>
        /// </list>
        /// <para>
        /// If the parameter is of type <see cref="String"/> then the wizard will search for the page with the corresponding name.
        /// If the page is not found, then the wizard will try to convert the string to <see cref="Int32"/> 
        /// and use it as the index in <see cref="Wizard.Pages"/> collection.
        /// </para>
        /// </remarks>
        public static ICommand NextPage
        {
            get
            {
                return nextPageCommand;
            }
        }

        /// <summary>
        /// Makes the wizard go to the previous page.
        /// </summary>
        public static ICommand PreviousPage
        {
            get
            {
                return previousPageCommand;
            }
        }

        /// <summary>
        /// Finishes the wizard..
        /// </summary>
        public static ICommand Finish
        {
            get
            {
                return finishCommand;
            }
        }

        /// <summary>
        /// Cancels the wizard.
        /// </summary>
        public static ICommand Cancel
        {
            get
            {
                return cancelCommand;
            }
        }
    }
}
