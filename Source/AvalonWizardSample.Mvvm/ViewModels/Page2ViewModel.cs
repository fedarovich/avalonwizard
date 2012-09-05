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
using System.Collections.Generic;
using System.Linq;
using AvalonWizard.Mvvm;
using GalaSoft.MvvmLight.Command;

namespace AvalonWizardSample.Mvvm.ViewModels
{
    public class Page2ViewModel : WizardPageViewModelBase
    {
        private readonly object skipToPage;
        private readonly IList<OperationViewModel> operations;

        public Page2ViewModel(Object skipToPage, IList<OperationViewModel> operations)
        {
            Header = "Page 3: Operation Selection";

            this.skipToPage = skipToPage;
            this.operations = operations;
            CommitCommand = new RelayCommand(CommitCommandExecute);
        }

        private void CommitCommandExecute()
        {
            NextPage = operations.Any(op => op.IsSelected) ? null : skipToPage;
        }

        public IList<OperationViewModel> Operations
        {
            get { return operations; }
        }
    }
}
