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
