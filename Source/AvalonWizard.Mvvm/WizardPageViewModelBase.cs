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
    /// The base implementation of <see cref="IWizardPageViewModel"/>.
    /// It's recommended to inherit your page view models from this class.
    /// </summary>
    public class WizardPageViewModelBase : IWizardPageViewModel
    {
        private object header;
        private string subtitle;
        private ImageSource icon;
        private bool isFinishPage = false;
        private bool allowCancel = true;
        private bool allowNext = true;
        private bool allowBack = true;
        private bool allowFinish = true;
        private bool showCancel = true;
        private bool showNext = true;
        private bool showBack = true;
        private object nextPage;

        /// <summary>
        /// Occurs when property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the page header.
        /// </summary>
        /// <value>The page header.</value>
        public object Header
        {
            get { return header; }
            set
            {
                header = value;
                NotifyOfPropertyChanged("Header");
            }
        }

        /// <summary>
        /// Gets or sets the subtitle.
        /// </summary>
        /// <value>The subtitle.</value>
        public string Subtitle
        {
            get { return subtitle; }
            set
            {
                subtitle = value;
                NotifyOfPropertyChanged("Subtitle");
            }
        }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The icon.</value>
        public ImageSource Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                NotifyOfPropertyChanged("Icon");
            }
        }

        /// <summary>
        /// Identifies the page as a the last page of the wizard.
        /// </summary>
        /// <remarks>
        /// You may set this property on several pages if your wizard requires non-linear navigation.
        /// </remarks>
        public bool IsFinishPage
        {
            get { return isFinishPage; }
            set
            {
                isFinishPage = value;
                NotifyOfPropertyChanged("IsFinishPage");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the Cancel button is enabled on this page.
        /// </summary>
        public bool AllowCancel
        {
            get { return allowCancel; }
            set
            { 
                allowCancel = value;
                NotifyOfPropertyChanged("AllowCancel");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the Next button is enabled on this page.
        /// </summary>
        public bool AllowNext
        {
            get { return allowNext; }
            set
            {
                allowNext = value;
                NotifyOfPropertyChanged("AllowNext");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the Back button is enabled on this page.
        /// </summary>
        public bool AllowBack
        {
            get { return allowBack; }
            set
            {
                allowBack = value;
                NotifyOfPropertyChanged("AllowBack");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the Finish button is enabled on this page.
        /// </summary>
        public bool AllowFinish
        {
            get { return allowFinish; }
            set
            {
                allowFinish = value;
                NotifyOfPropertyChanged("AllowFinish");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the Cancel button is visible on this page.
        /// </summary>
        public bool ShowCancel
        {
            get { return showCancel; }
            set
            {
                showCancel = value;
                NotifyOfPropertyChanged("ShowCancel");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the Next button is visible on this page.
        /// </summary>
        public bool ShowNext
        {
            get { return showNext; }
            set
            {
                showNext = value;
                NotifyOfPropertyChanged("ShowNext");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the Back button is visible on this page.
        /// </summary>
        public bool ShowBack
        {
            get { return showBack; }
            set
            {
                showBack = value;
                NotifyOfPropertyChanged("ShowBack");
            }
        }

        /// <summary>
        /// Gets or sets the next page view model.
        /// </summary>
        /// <value>The next page view model.</value>
        public object NextPage
        {
            get { return nextPage; }
            set
            {
                nextPage = value;
                NotifyOfPropertyChanged("NextPage");
            }
        }

        /// <summary>
        /// Gets or sets the commit command.
        /// </summary>
        /// <value>The commit command.</value>
        public ICommand CommitCommand
        {
            get; 
            protected set;
        }

        /// <summary>
        /// Gets or sets the rollback command.
        /// </summary>
        /// <value>The rollback command.</value>
        public ICommand RollbackCommand
        {
            get; 
            protected set;
        }

        /// <summary>
        /// Gets or sets the initialize command.
        /// </summary>
        /// <value>The initialize command.</value>
        public ICommand InitializeCommand
        {
            get; 
            protected set;
        }

        /// <summary>
        /// Notifies the view of property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyOfPropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
