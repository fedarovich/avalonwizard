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
    /// The parameters for <see cref="WizardPageMvvmBehavior.InitializeCommand"/>.
    /// </summary>
    public class WizardPageInitParameters
    {
        private readonly WizardPageInitEventArgs args;

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardPageInitParameters" /> class.
        /// </summary>
        /// <param name="args">The <see cref="WizardPageInitEventArgs" /> instance containing the event data.</param>
        public WizardPageInitParameters(WizardPageInitEventArgs args)
        {
            this.args = args;
        }

        /// <summary>
        /// Gets the underlying event args.
        /// </summary>
        /// <value>The event args.</value>
        public WizardPageInitEventArgs EventArgs
        {
            get { return args; }
        }

        /// <summary>
        /// Gets the view model that has invoked the command.
        /// </summary>
        /// <value>The wizard page view model.</value>
        public Object Page
        {
            get { return args.Page.DataContext; }
        }

        /// <summary>
        /// Gets the view model of the page that was previously selected when the command was invoked.
        /// </summary>
        /// <value>The previous wizard page view model.</value>
        public Object PreviousPage
        {
            get { return args.PreviousPage.DataContext; }
        }
    }
}
