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
using Microsoft.Windows.Design.Model;

namespace AvalonWizard.Design.Adorners
{
    internal class WizardAdornerViewModel : IDisposable, INotifyPropertyChanged
    {
        public WizardAdornerViewModel(ModelItem wizard)
        {
            this.wizard = wizard;

            wizard.PropertyChanged += OnWizardPropertyChanged;

            goToFirstPage = new DelegateCommand(GoToFirstPageExecuted, CanGoToFirstPage);
            goToPreviousPage = new DelegateCommand(GoToPreviousPageExecuted, CanGoToPreviousPage);
            goToNextPage = new DelegateCommand(GoToNextPageExecuted, CanGoToNextPage);
            goToLastPage = new DelegateCommand(GoToLastPageExecuted, CanGoToLastPage);

            addPage = new DelegateCommand(AddPageExecuted);
            insertPage = new DelegateCommand(InsertPageExecuted);
            removePage = new DelegateCommand(RemovePageExecuted, CanRemovePage);
        }

        private void OnWizardPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(null);
        }

        public int PageIndex
        {
            get
            {
                return DesignerOperations.GetCurrentPageIndex(wizard);
            }
            set
            {
                DesignerOperations.SetCurrentPageIndex(wizard, value);
                RaisePropertyChanged("PageIndex");
            }
        }

        #region [Commands]

        #region [GoToFirstPage]

        private readonly DelegateCommand goToFirstPage;
        
        public ICommand GoToFirstPage
        {
            get { return goToFirstPage; }
        }

        private void GoToFirstPageExecuted(Object param)
        {
            if (wizard != null)
            {
                DesignerOperations.GoToFirstPage(wizard);
            }
        }

        private bool CanGoToFirstPage(Object param)
        {
            if (wizard != null)
            {
                return DesignerOperations.CanGoToFirstPage(wizard);
            }
            return false;
        }

        #endregion [GoToFirstPage]

        #region [GoToPreviousPage]

        private readonly DelegateCommand goToPreviousPage;

        public ICommand GoToPreviousPage
        {
            get { return goToPreviousPage; }
        }

        private void GoToPreviousPageExecuted(Object param)
        {
            if (wizard != null)
            {
                DesignerOperations.GoToPreviousPage(wizard);
            }
        }

        private bool CanGoToPreviousPage(Object param)
        {
            if (wizard != null)
            {
                return DesignerOperations.CanGoToPreviousPage(wizard);
            }
            return false;
        }

        #endregion [GoToPreviousPage]

        #region [GoToNextPage]

        private readonly DelegateCommand goToNextPage;

        public ICommand GoToNextPage
        {
            get { return goToNextPage; }
        }

        private void GoToNextPageExecuted(Object param)
        {
            if (wizard != null)
            {
                DesignerOperations.GoToNextPage(wizard);
            }
        }

        private bool CanGoToNextPage(Object param)
        {
            if (wizard != null)
            {
                return DesignerOperations.CanGoToNextPage(wizard);
            }
            return false;
        }

        #endregion [GoToNextPage]

        #region [GoToLastPage]

        private readonly DelegateCommand goToLastPage;

        public ICommand GoToLastPage
        {
            get { return goToLastPage; }
        }

        private void GoToLastPageExecuted(Object param)
        {
            if (wizard != null)
            {
                DesignerOperations.GoToLastPage(wizard);
            }
        }

        private bool CanGoToLastPage(Object param)
        {
            if (wizard != null)
            {
                return DesignerOperations.CanGoToLastPage(wizard);
            }
            return false;
        }

        #endregion [GoToLastPage]

        #region [AddPage]

        private DelegateCommand addPage;

        public ICommand AddPage
        {
            get { return addPage; }
        }

        private void AddPageExecuted(Object param)
        {
            if (wizard != null)
            {
                DesignerOperations.AddPage(wizard);
            }
        }

        #endregion [AddPage]

        #region [InsertPage]

        private DelegateCommand insertPage;

        public ICommand InsertPage
        {
            get { return insertPage; }
        }

        private void InsertPageExecuted(Object param)
        {
            if (wizard != null)
            {
                DesignerOperations.InsertPage(wizard);
            }
        }

        #endregion [InsertPage]

        #region [RemovePage]

        private DelegateCommand removePage;

        public ICommand RemovePage
        {
            get { return removePage; }
        }

        private void RemovePageExecuted(Object param)
        {
            if (wizard != null)
            {
                DesignerOperations.RemovePage(wizard);
            }
        }

        private bool CanRemovePage(Object param)
        {
            if (wizard != null)
            {
                return DesignerOperations.CanRemovePage(wizard);
            }
            return false;
        }

        #endregion [RemovePage]

        #endregion [Commands]

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            if (wizard != null)
            {
                wizard.PropertyChanged -= OnWizardPropertyChanged;
            }
        }

        #endregion

        #region Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        private ModelItem wizard;
    }
}
