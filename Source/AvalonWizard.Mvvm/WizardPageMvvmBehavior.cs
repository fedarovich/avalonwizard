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

using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace AvalonWizard.Mvvm
{
    /// <summary>
    /// The behavior to be attached to <see cref="WizardPage"/> in order to support MVVM pattern.
    /// You usually don't use this behavior yourself. Instead it is automatically added to the pages
    /// by <see cref="WizardMvvmBehavior"/> attached to the <see cref="Wizard"/> control.
    /// </summary>
    public class WizardPageMvvmBehavior : Behavior<WizardPage>
    {
        #region [InitializeCommand]

        /// <summary>
        /// Gets or sets the initialize command.
        /// </summary>
        /// <value>The initialize command.</value>
        public ICommand InitializeCommand
        {
            get { return (ICommand)GetValue(InitializeCommandProperty); }
            set { SetValue(InitializeCommandProperty, value); }
        }

        #endregion

        /// <summary>
        /// Identifies <see cref="InitializeCommand"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty InitializeCommandProperty =
            DependencyProperty.Register("InitializeCommand", typeof(ICommand), typeof(WizardPageMvvmBehavior), 
            new UIPropertyMetadata(null));

        #region [CommitCommand]

        /// <summary>
        /// Gets or sets the commit command.
        /// </summary>
        /// <value>The commit command.</value>
        public ICommand CommitCommand
        {
            get { return (ICommand)GetValue(CommitCommandProperty); }
            set { SetValue(CommitCommandProperty, value); }
        }

        /// <summary>
        /// Identifies <see cref="CommitCommand"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty CommitCommandProperty =
            DependencyProperty.Register("CommitCommand", typeof(ICommand), typeof(WizardPageMvvmBehavior), 
            new UIPropertyMetadata(null));

        #endregion

        #region [RollbackCommand]

        /// <summary>
        /// Gets or sets the rollback command.
        /// </summary>
        /// <value>The rollback command.</value>
        public ICommand RollbackCommand
        {
            get { return (ICommand)GetValue(RollbackCommandProperty); }
            set { SetValue(RollbackCommandProperty, value); }
        }

        /// <summary>
        /// Identifies <see cref="RollbackCommand"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty RollbackCommandProperty =
            DependencyProperty.Register("RollbackCommand", typeof(ICommand), typeof(WizardPageMvvmBehavior), 
            new UIPropertyMetadata(null));

        #endregion

        #region [NextPage]

        /// <summary>
        /// Gets or sets the next page view model.
        /// </summary>
        /// <value>The next page view model.</value>
        public object NextPage
        {
            get { return (object)GetValue(NextPageProperty); }
            set { SetValue(NextPageProperty, value); }
        }

        /// <summary>
        /// Identifies <see cref="NextPage"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty NextPageProperty =
            DependencyProperty.Register("NextPage", typeof(object), typeof(WizardPageMvvmBehavior), 
            new UIPropertyMetadata(null, OnNextPageChanged));

        #endregion

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Initialize += OnInitialize;
            AssociatedObject.Commit += OnCommit;
            AssociatedObject.Rollback += OnRollback;
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Initialize -= OnInitialize;
            AssociatedObject.Commit -= OnCommit;
            AssociatedObject.Rollback -= OnRollback;
        }

        private void OnInitialize(object sender, WizardPageInitEventArgs e)
        {
            UpdateNextPage();
            if (InitializeCommand != null)
            {
                InitializeCommand.Execute(new WizardPageInitParameters(e));
            }
        }

        private void OnCommit(object sender, WizardPageConfirmEventArgs e)
        {
            InvokeCommand(CommitCommand, new WizardPageConfirmParameters(e));
        }

        private void OnRollback(object sender, WizardPageConfirmEventArgs e)
        {
            InvokeCommand(RollbackCommand, new WizardPageConfirmParameters(e));
        }

        private void InvokeCommand(ICommand command, WizardPageConfirmParameters parameters)
        {
            if (command != null)
            {
                if (command.CanExecute(parameters))
                {
                    command.Execute(parameters);
                }
                else
                {
                    parameters.Cancel = true;
                }
            }
        }

        private static void OnNextPageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = (WizardPageMvvmBehavior)d;
            behavior.UpdateNextPage();
        }

        private void UpdateNextPage()
        {
            if (AssociatedObject.Wizard != null)
            {
                AssociatedObject.NextPage = AssociatedObject.Wizard.Pages.FirstOrDefault(
                    page => page.DataContext == NextPage);
            }
        }
    }
}
