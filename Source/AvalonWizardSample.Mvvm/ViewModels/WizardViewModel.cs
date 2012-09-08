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
using AvalonWizard;
using AvalonWizard.Mvvm;
using GalaSoft.MvvmLight;

namespace AvalonWizardSample.Mvvm.ViewModels
{
    public class WizardViewModel : ViewModelBase
    {
        private readonly IWizardController wizardController = new WizardController();
        private WizardStyle selectedStyle;
        
        public WizardViewModel()
        {
            var operations = Enumerable.Range(1, 10)
                .Select(i => new OperationViewModel("Operation " + i))
                .ToArray();

            var page4 = new Page4ViewModel();

            Pages = new List<Object>
            {
                new Page0ViewModel(),
                new Page1ViewModel(),
                new Page2ViewModel(page4, operations, wizardController),
                new Page3ViewModel(page4, operations, wizardController),
                page4
            };

            WizardStyles = Enum.GetValues(typeof (WizardStyle)).Cast<WizardStyle>().ToList();
        }

        public IList<Object> Pages
        {
            get;
            private set;
        }

        public IList<WizardStyle> WizardStyles
        {
            get;
            private set;
        }

        public WizardStyle SelectedStyle
        {
            get { return selectedStyle; }
            set
            {
                if (selectedStyle != value)
                {
                    selectedStyle = value;
                    RaisePropertyChanged("SelectedStyle");
                }
            }
        }

        public IWizardController WizardController
        {
            get { return wizardController; }
        }
    }
}
