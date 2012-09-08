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
    /// Parameters for <see cref="IWizardPageViewModel.CommitCommand"/> 
    /// and <see cref="IWizardPageViewModel.RollbackCommand"/>.
    /// </summary>
    public class WizardPageConfirmParameters
    {
        private readonly WizardPageConfirmEventArgs args;

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardPageConfirmParameters" /> class.
        /// </summary>
        /// <param name="args">The <see cref="WizardPageConfirmEventArgs" /> instance containing the event data.</param>
        public WizardPageConfirmParameters(WizardPageConfirmEventArgs args)
        {
            this.args = args;
        }

        /// <summary>
        /// Gets the underlying event args.
        /// </summary>
        public WizardPageConfirmEventArgs EventArgs
        {
            get { return args; }
        }

        /// <summary>
        /// Gets the view model of the page that has invoked the command.
        /// </summary>
        /// <value>The wizard page.</value>
        public Object Page
        {
            get { return args.Page.DataContext; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this action is to be cancelled or allowed.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c> to allow. Default is <c>false</c>.</value>
        public bool Cancel
        {
            get { return args.Cancel; }
            set { args.Cancel = value; }
        }
    }
}
