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
using GalaSoft.MvvmLight;

namespace AvalonWizardSample.Mvvm.ViewModels
{
    public sealed class OperationViewModel : ViewModelBase
    {
        private bool isSelected;

        private String name;

        private readonly TimeSpan duration;

        private static readonly Random random = new Random();

        public OperationViewModel(String name)
        {
            this.name = name;
            duration = TimeSpan.FromSeconds(2 + random.NextDouble() * 3);
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected == value)
                    return;

                isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name == value)
                    return;

                name = value;
                RaisePropertyChanged("IsSelected");
            }
        }

        public TimeSpan Duration
        {
            get { return duration; }
        }
    }
}
