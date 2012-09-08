﻿#region License
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

using System.Windows;

namespace AvalonWizard
{
    /// <summary>
    /// Provides data for the <see cref = "WizardPage.Initialize" /> event.
    /// </summary>
    public class WizardPageInitEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        /// <param name="page">
        /// The <see cref="WizardPage" /> that has raised the event.
        /// </param>
        /// <param name="previousPage">
        /// The <see cref="WizardPage" /> that was previously selected when the event was raised.
        /// </param>
        internal WizardPageInitEventArgs(WizardPage page, WizardPage previousPage)
        {
            Page = page;
            PreviousPage = previousPage;
        }

        /// <summary>
        /// Gets the <see cref="WizardPage" /> that has raised the event.
        /// </summary>
        /// <value>The wizard page.</value>
        public WizardPage Page { get; private set; }

        /// <summary>
        /// Gets the <see cref="WizardPage" /> that was previously selected when the event was raised.
        /// </summary>
        /// <value>The previous wizard page.</value>
        public WizardPage PreviousPage { get; private set; }
    }
}
