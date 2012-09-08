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

using System;

namespace AvalonWizard.Mvvm
{
    /// <summary>
    /// Provides operation for performing wizard navigation from view model.
    /// </summary>
    public interface IWizardController
    {
        /// <summary>
        /// Asks the wizard to go to the next page.
        /// </summary>
        void NextPage();

        /// <summary>
        /// Asks the wizard to go to the specified page.
        /// </summary>
        /// <param name="nextPage">
        /// The page to go. The value can be one of the following:
        /// <list type="table">
        ///     <listheader>
        ///         <term>Type</term>
        ///         <description>Interpretation</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="Int32"/></term>
        ///         <description>The page index.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="String"/></term>
        ///         <description>The page name.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="WizardPage"/></term>
        ///         <description>The page.</description>
        ///     </item>
        ///     <item>
        ///         <term>Any other object.</term>
        ///         <description>The page having the paratemer as its view model.</description>
        ///     </item>
        ///     <item>
        ///         <term><c>null</c></term>
        ///         <description>The next page.</description>
        ///     </item>
        /// </list>
        /// </param>
        void NextPage(Object nextPage);

        /// <summary>
        /// Asks the wizard to go back.
        /// </summary>
        void PreviousPage();

        /// <summary>
        /// Asks the wizard to finish.
        /// </summary>
        void Finish();

        /// <summary>
        /// Asks the wizard to cancel.
        /// </summary>
        void Cancel();

        /// <summary>
        /// Notifies the wizard that the navigation is exprected.
        /// </summary>
        event EventHandler<WizardNavigationEventArgs> NavigationRequested;

        /// <summary>
        /// Notifies the wizard that finishing is requested..
        /// </summary>
        event EventHandler FinishRequested;

        /// <summary>
        /// Notifies the wizard that cancellation is requested.
        /// </summary>
        event EventHandler CancelRequested;
    }
}
