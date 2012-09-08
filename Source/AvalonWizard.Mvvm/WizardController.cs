using System;

namespace AvalonWizard.Mvvm
{
    /// <summary>
    /// The default implementation of <see cref="IWizardController"/>.
    /// </summary>
    public class WizardController : IWizardController
    {
        /// <summary>
        /// Asks the wizard to go to the next page.
        /// </summary>
        public void NextPage()
        {
            NavigationRequested(this, new WizardNavigationEventArgs(WizardNavigationDirection.Forward));
        }

        /// <summary>
        /// Asks the wizard to go to the specified page.
        /// </summary>
        /// <param name="nextPage">
        /// The page to go. The value can be one of the following:
        /// <list type="table">
        ///     <listheader>
        ///         <term>Type</term>
        ///         <description>Interpretation</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="Int32"/></term>
        ///         <description>The page index.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="String"/></term>
        ///         <description>The page name.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="WizardPage"/></term>
        ///         <description>The page.</description>
        ///     </item>
        ///     <item>
        ///         <term>Any other object.</term>
        ///         <description>The page having the paratemer as its view model.</description>
        ///     </item>
        ///     <item>
        ///         <term><c>null</c></term>
        ///         <description>The next page.</description>
        ///     </item>
        /// </list>
        /// </param>
        public void NextPage(object nextPage)
        {
            NavigationRequested(this, new WizardNavigationEventArgs(nextPage));
        }

        /// <summary>
        /// Asks the wizard to go back.
        /// </summary>
        public void PreviousPage()
        {
            NavigationRequested(this, new WizardNavigationEventArgs(WizardNavigationDirection.Back));
        }

        /// <summary>
        /// Asks the wizard to finish.
        /// </summary>
        public void Finish()
        {
            FinishRequested(this, EventArgs.Empty);
        }

        /// <summary>
        /// Asks the wizard to cancel.
        /// </summary>
        public void Cancel()
        {
            CancelRequested(this, EventArgs.Empty);
        }

        /// <summary>
        /// Notifies the wizard that the navigation is exprected.
        /// </summary>
        public event EventHandler<WizardNavigationEventArgs> NavigationRequested = delegate { };

        /// <summary>
        /// Notifies the wizard that finishing is requested..
        /// </summary>
        public event EventHandler FinishRequested = delegate { };

        /// <summary>
        /// Notifies the wizard that cancellation is requested.
        /// </summary>
        public event EventHandler CancelRequested = delegate { };
    }
}
