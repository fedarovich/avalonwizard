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
        /// <summary>
        /// Gets or sets the initialize command.
        /// </summary>
        /// <value>The initialize command.</value>
        public ICommand InitializeCommand
        {
            get { return (ICommand)GetValue(InitializeCommandProperty); }
            set { SetValue(InitializeCommandProperty, value); }
        }

        /// <summary>
        /// Identifies <see cref="InitializeCommand"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty InitializeCommandProperty =
            DependencyProperty.Register("InitializeCommand", typeof(ICommand), typeof(WizardPageMvvmBehavior), 
            new UIPropertyMetadata(null));

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
                InitializeCommand.Execute(e);
            }
        }

        private void OnCommit(object sender, WizardPageConfirmEventArgs e)
        {
            InvokeCommand(CommitCommand, e);
        }

        private void OnRollback(object sender, WizardPageConfirmEventArgs e)
        {
            InvokeCommand(RollbackCommand, e);
        }

        private void InvokeCommand(ICommand command, WizardPageConfirmEventArgs e)
        {
            if (command != null)
            {
                if (command.CanExecute(e))
                {
                    command.Execute(e);
                }
                else
                {
                    e.Cancel = true;
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
