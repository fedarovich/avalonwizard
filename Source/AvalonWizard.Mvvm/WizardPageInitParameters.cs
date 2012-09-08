using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvalonWizard.Mvvm
{
    /// <summary>
    /// The parameters for <see cref="WizardPageMvvmBehavior.InitializeCommand"/>.
    /// </summary>
    public class WizardPageInitParameters
    {
        private readonly WizardPageInitEventArgs args;

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardPageInitParameters" /> class.
        /// </summary>
        /// <param name="args">The <see cref="WizardPageInitEventArgs" /> instance containing the event data.</param>
        public WizardPageInitParameters(WizardPageInitEventArgs args)
        {
            this.args = args;
        }

        /// <summary>
        /// Gets the underlying event args.
        /// </summary>
        /// <value>The event args.</value>
        public WizardPageInitEventArgs EventArgs
        {
            get { return args; }
        }

        /// <summary>
        /// Gets the view model that has invoked the command.
        /// </summary>
        /// <value>The wizard page view model.</value>
        public Object Page
        {
            get { return args.Page.DataContext; }
        }

        /// <summary>
        /// Gets the view model of the page that was previously selected when the command was invoked.
        /// </summary>
        /// <value>The previous wizard page view model.</value>
        public Object PreviousPage
        {
            get { return args.PreviousPage.DataContext; }
        }
    }
}
