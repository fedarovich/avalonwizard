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
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;

namespace AvalonWizard.Mvvm
{
    /// <summary>
    /// Describes the standard view model of a wizard page. 
    /// If your view model implement this interface, its properties will be 
    /// automatically bound to the corresponding <see cref="WizardPage"/>.
    /// </summary>
    public interface IWizardPageViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets the page header.
        /// </summary>
        /// <value>The page header.</value>
        Object Header { get; set; }

        /// <summary>
        /// Gets or sets the subtitle.
        /// </summary>
        /// <value>The subtitle.</value>
        String Subtitle { get; set; }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        ImageSource Icon { get; set; }

        /// <summary>
        /// Identifies the page as a the last page of the wizard.
        /// </summary>
        /// <remarks>
        /// You may set this property on several pages if your wizard requires non-linear navigation.
        /// </remarks>
        bool IsFinishPage { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the Cancel button is enabled on this page.
        /// </summary>
        bool AllowCancel { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the Next button is enabled on this page.
        /// </summary>
        bool AllowNext { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the Back button is enabled on this page.
        /// </summary>
        bool AllowBack { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the Finish button is enabled on this page.
        /// </summary>
        bool AllowFinish { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the Cancel button is visible on this page.
        /// </summary>
        bool ShowCancel { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the Next button is visible on this page.
        /// </summary>
        bool ShowNext { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the Back button is visible on this page.
        /// </summary>
        bool ShowBack { get; set; }

        /// <summary>
        /// Gets or sets the next page view model.
        /// </summary>
        /// <value>The next page view model.</value>
        Object NextPage { get; set; }

        /// <summary>
        /// Gets or sets the commit command.
        /// </summary>
        /// <value>The commit command.</value>
        ICommand CommitCommand { get; }

        /// <summary>
        /// Gets or sets the rollback command.
        /// </summary>
        /// <value>The rollback command.</value>
        ICommand RollbackCommand { get; }

        /// <summary>
        /// Gets or sets the initialize command.
        /// </summary>
        /// <value>The initialize command.</value>
        ICommand InitializeCommand { get; }
    }
}
