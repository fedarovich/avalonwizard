using System;

namespace AvalonWizard.Mvvm
{
    /// <summary>
    /// Parameters for <see cref="IWizardPageViewModel.CommitCommand"/> 
    /// and <see cref="IWizardPageViewModel.RollbackCommand"/>.
    /// </summary>
    public class WizardPageConfirmParameters
    {
        private readonly WizardPageConfirmEventArgs args;

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardPageConfirmParameters" /> class.
        /// </summary>
        /// <param name="args">The <see cref="WizardPageConfirmEventArgs" /> instance containing the event data.</param>
        public WizardPageConfirmParameters(WizardPageConfirmEventArgs args)
        {
            this.args = args;
        }

        /// <summary>
        /// Gets the underlying event args.
        /// </summary>
        public WizardPageConfirmEventArgs EventArgs
        {
            get { return args; }
        }

        /// <summary>
        /// Gets the view model of the page that has invoked the command.
        /// </summary>
        /// <value>The wizard page.</value>
        public Object Page
        {
            get { return args.Page.DataContext; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this action is to be cancelled or allowed.
        /// </summary>
        /// <value><c>true</c> if cancel; otherwise, <c>false</c> to allow. Default is <c>false</c>.</value>
        public bool Cancel
        {
            get { return args.Cancel; }
            set { args.Cancel = value; }
        }
    }
}
