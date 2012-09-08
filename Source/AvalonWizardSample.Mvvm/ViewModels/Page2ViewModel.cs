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
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using AvalonWizard.Mvvm;
using GalaSoft.MvvmLight.Command;

namespace AvalonWizardSample.Mvvm.ViewModels
{
    public class Page2ViewModel : WizardPageViewModelBase
    {
        private readonly object skipToPage;
        private readonly IList<OperationViewModel> operations;
        private readonly IWizardController wizardController;

        public Page2ViewModel(Object skipToPage, 
            IList<OperationViewModel> operations,
            IWizardController wizardController)
        {
            Header = "Page 3: Operation Selection";

            this.skipToPage = skipToPage;
            this.operations = operations;
            this.wizardController = wizardController;
            CommitCommand = new RelayCommand(CommitCommandExecute);
            SkipCommand = new RelayCommand(SkipCommandExecute);
        }

        public IList<OperationViewModel> Operations
        {
            get { return operations; }
        }

        public ICommand SkipCommand
        {
            get;
            private set;
        }

        private void CommitCommandExecute()
        {
            NextPage = operations.Any(op => op.IsSelected) ? null : skipToPage;
        }

        private void SkipCommandExecute()
        {
            wizardController.NextPage(skipToPage);
        }
    }
}
