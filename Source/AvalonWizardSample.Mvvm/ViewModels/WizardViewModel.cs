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
using System.ComponentModel;
using System.Linq;
using System.Text;
using AvalonWizard;

namespace AvalonWizardSample.Mvvm.ViewModels
{
    public class WizardViewModel : INotifyPropertyChanged
    {
        private WizardStyle selectedStyle;

        public WizardViewModel()
        {
            Pages = new List<Object>
            {
                new Page0ViewModel(),
                new Page1ViewModel()
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
                    OnPropertyChanged("SelectedStyle");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
