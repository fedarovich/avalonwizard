using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AvalonWizard
{
    public class WizardPage : HeaderedContentControl
    {
        static WizardPage()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WizardPage), new FrameworkPropertyMetadata(typeof(WizardPage)));
        }

        #region [Properties]

        /// <summary>
        /// Gets the <see cref = "Wizard" /> for this page.
        /// </summary>
        [Browsable(false)]
        public Wizard Owner
        {
            get
            {
                return ItemsControl.ItemsControlFromItemContainer(this) as Wizard;
            }
        }

        /// <summary>
        /// <para>
        /// Gets or sets the next page that should be used when the user clicks the Next button 
        /// or when the <see cref = "Wizard.NextPage()" /> method is called. 
        /// </para>
        /// <para>
        /// This is used to override the default behavior of going to the next page 
        /// in the sequence defined within the <see cref = "Wizard.Items" /> collection.
        /// </para>
        /// </summary>
        /// <value>The wizard page to go to.</value>
        [DefaultValue(null)]
        [Category("Behavior")]
        [Description("Specify a page other than the next page in the Pages collection as the next page.")]
        public virtual WizardPage NextPage
        {
            get; 
            set;
        }

        #endregion [Properties]

        #region [Dependency Properties]

        #region [IsFinishPage Property]

        [DefaultValue(false)]
        public bool IsFinishPage
        {
            get { return (bool)GetValue(IsFinishPageProperty); }
            set { SetValue(IsFinishPageProperty, value); }
        }

        public static readonly DependencyProperty IsFinishPageProperty =
            DependencyProperty.Register("IsFinishPage", typeof(bool), typeof(WizardPage), new UIPropertyMetadata(false));

        #endregion [IsFinishPage Property]

        #region [AllowCancel Property]

        [DefaultValue(true)]
        public bool AllowCancel
        {
            get { return (bool)GetValue(AllowCancelProperty); }
            set { SetValue(AllowCancelProperty, value); }
        }

        public static readonly DependencyProperty AllowCancelProperty =
            DependencyProperty.Register("AllowCancel", typeof(bool), typeof(WizardPage), new UIPropertyMetadata(true));

        #endregion

        #region [AllowNext Property]

        [DefaultValue(true)]
        public bool AllowNext
        {
            get { return (bool)GetValue(AllowNextProperty); }
            set { SetValue(AllowNextProperty, value); }
        }

        public static readonly DependencyProperty AllowNextProperty =
            DependencyProperty.Register("AllowNext", typeof(bool), typeof(WizardPage), new UIPropertyMetadata(true));

        #endregion [AllowNext Property]

        #region [ShowCancel Property]

        [DefaultValue(true)]
        public bool ShowCancel
        {
            get { return (bool)GetValue(ShowCancelProperty); }
            set { SetValue(ShowCancelProperty, value); }
        }

        public static readonly DependencyProperty ShowCancelProperty =
            DependencyProperty.Register("ShowCancel", typeof(bool), typeof(WizardPage), new UIPropertyMetadata(true));

        #endregion

        #region [ShowNext Property]

        [DefaultValue(true)]
        public bool ShowNext
        {
            get { return (bool)GetValue(ShowNextProperty); }
            set { SetValue(ShowNextProperty, value); }
        }

        public static readonly DependencyProperty ShowNextProperty =
            DependencyProperty.Register("ShowNext", typeof(bool), typeof(WizardPage), new UIPropertyMetadata(true));

        #endregion [ShowNext Property]

        #endregion [Dependency Properties]

        #region [Events]

        #region [Initialize Event]

        public static readonly RoutedEvent InitializeEvent = EventManager.RegisterRoutedEvent(
            "Initialize", RoutingStrategy.Bubble, typeof(EventHandler<WizardPageInitEventArgs>), typeof(WizardPage));

        public event EventHandler<WizardPageInitEventArgs> Initialize
        {
            add { AddHandler(InitializeEvent, value); }
            remove { RemoveHandler(InitializeEvent, value); }
        }

        protected virtual void OnInitialize(WizardPageInitEventArgs args)
        {
            args.RoutedEvent = InitializeEvent;
            RaiseEvent(args);
        }

        #endregion [Initialize Event]

        #region [Commit Event]

        public static readonly RoutedEvent CommitEvent = EventManager.RegisterRoutedEvent(
            "Commit", RoutingStrategy.Bubble, typeof(EventHandler<WizardPageConfirmEventArgs>), typeof(WizardPage));

        public event EventHandler<WizardPageConfirmEventArgs> Commit
        {
            add { AddHandler(CommitEvent, value); }
            remove { RemoveHandler(CommitEvent, value); }
        }

        protected virtual void OnCommit(WizardPageConfirmEventArgs args)
        {
            args.RoutedEvent = CommitEvent;
            RaiseEvent(args);
        }

        #endregion [Commit Event]

        #region [Rollback Event]

        public static readonly RoutedEvent RollbackEvent = EventManager.RegisterRoutedEvent(
            "Rollback", RoutingStrategy.Bubble, typeof(EventHandler<WizardPageConfirmEventArgs>), typeof(WizardPage));

        public event EventHandler<WizardPageConfirmEventArgs> Rollback
        {
            add { AddHandler(RollbackEvent, value); }
            remove { RemoveHandler(RollbackEvent, value); }
        }

        protected virtual void OnRollback(WizardPageConfirmEventArgs args)
        {
            args.RoutedEvent = RollbackEvent;
            RaiseEvent(args);
        }

        #endregion [Rollback Event]

        #endregion [Events]

        #region [Internal Methods]

        internal void InitializePage(WizardPage previousPage)
        {
            var args = new WizardPageInitEventArgs(this, previousPage);
            OnInitialize(args);
        }

        internal bool CommitPage()
        {
            var args = new WizardPageConfirmEventArgs(this);
            OnCommit(args);
            return !args.Cancel;
        }

        internal bool RollbackPage()
        {
            var args = new WizardPageConfirmEventArgs(this);
            OnRollback(args);
            return !args.Cancel;
        }

        #endregion
    }
}
