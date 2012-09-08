using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using AvalonWizard.Mvvm;
using GalaSoft.MvvmLight.Command;

namespace AvalonWizardSample.Mvvm.ViewModels
{
    public class Page3ViewModel : WizardPageViewModelBase
    {
        private readonly IList<OperationViewModel> operations;
        private readonly object resultPage;
        private readonly IWizardController wizardController;
        private readonly DispatcherTimer timer = new DispatcherTimer();

        private int operationCount;
        private int currentOperation;
        private String progressText;
        private bool initComplete;
        private bool isFinishing;
        private bool showProgress;

        public Page3ViewModel(object resultPage, IList<OperationViewModel> operations, IWizardController wizardController)
        {
            Header = "Page 4: Operation Progress";

            this.operations = operations;
            this.resultPage = resultPage;
            this.wizardController = wizardController;

            InitializeCommand = new RelayCommand<WizardPageInitParameters>(InitializeCommandExecute);
            timer.Tick += OnTimer;
        }

        private void InitializeCommandExecute(WizardPageInitParameters parameters)
        {
            if (parameters.PreviousPage == resultPage)
            {
                wizardController.PreviousPage();
                return;
            }

            OperationCount = operations.Count(op => op.IsSelected);
            CurrentOperation = 0;
            ProgressText = "Initializing...";
            ShowProgress = true;
            initComplete = false;
            isFinishing = false;

            AllowBack = false;
            AllowNext = false;

            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Start();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            if (!initComplete)
            {
                initComplete = true;
            }
            else
            {
                CurrentOperation += 1;
            }

            if (CurrentOperation < OperationCount)
            {
                ProgressText = String.Format(
                   "Executing operation {0} of {1}...", CurrentOperation + 1, OperationCount);
                timer.Interval = operations.Where(op => op.IsSelected).ElementAt(CurrentOperation).Duration;
            }
            else
            {
                if (!isFinishing)
                {
                    ProgressText = "Finishing...";
                    timer.Interval = TimeSpan.FromSeconds(3);
                    isFinishing = true;
                }
                else
                {
                    timer.Stop();
                    ProgressText = "All operations finished.";
                    AllowBack = true;
                    AllowNext = true;
                    ShowProgress = false;
                }
            }
        }

        public int OperationCount
        {
            get { return operationCount; }
            set
            {
                if (value == operationCount) return;
                operationCount = value;
                NotifyOfPropertyChanged("OperationCount");
            }
        }

        public int CurrentOperation
        {
            get { return currentOperation; }
            set
            {
                if (value == currentOperation) return;
                currentOperation = value;
                NotifyOfPropertyChanged("CurrentOperation");
            }
        }

        public string ProgressText
        {
            get { return progressText; }
            set
            {
                if (value == progressText) return;
                progressText = value;
                NotifyOfPropertyChanged("ProgressText");
            }
        }

        public bool ShowProgress
        {
            get { return showProgress; }
            set
            {
                if (value.Equals(showProgress)) return;
                showProgress = value;
                NotifyOfPropertyChanged("ShowProgress");
            }
        }
    }
}
