using System;
using System.ComponentModel;
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
