#region Licence
// This file is part of AvalonWizard.
// 
// AvalonWizard is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
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
