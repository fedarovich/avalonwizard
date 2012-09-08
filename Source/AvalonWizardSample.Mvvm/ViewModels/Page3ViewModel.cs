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
