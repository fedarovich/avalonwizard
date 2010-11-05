﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AvalonWizard.Extensions;

namespace AvalonWizard
{
    [DefaultProperty("Pages")]
    [ContentProperty("Pages")]
    public class Wizard : Control, IAddChild
    {
        #region [Constructors]

        public Wizard()
        {
            pages = new WizardPageCollection();
            pages.CollectionChanged += HandlePagesCollectionChanged;

            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (CurrentPage != null)
            {
                CurrentPage.InitializePage(null);
            }
        }

        static Wizard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Wizard), new FrameworkPropertyMetadata(typeof(Wizard)));
            
            var backBinding = new CommandBinding(WizardCommands.PreviousPage,
                OnBackCommand,
                OnBackCommandCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(Wizard), backBinding);

            var nextBinding = new CommandBinding(WizardCommands.NextPage,
                OnNextCommand,
                OnNextCommandCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(Wizard), nextBinding);

            var finishBinding = new CommandBinding(WizardCommands.Finish,
                OnFinishCommand,
                OnFinishCommandCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(Wizard), finishBinding);

            var cancelBinding = new CommandBinding(WizardCommands.Cancel,
                OnCancelCommand,
                OnCancelCommandCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(Wizard), cancelBinding);
        }

        #endregion [Constructors]

        #region [Public Methods]

        public virtual void NextPage()
        {
            NextPage(null);
        }

        public virtual void NextPage(WizardPage nextPage)
        {
            if (nextPage == null)
            {
                if (CurrentPage == Pages.Last() || CurrentPage.IsFinishPage)
                {
                    Finish();
                    return;
                }
            }
            else if (!Pages.Contains(nextPage))
            {
                throw new ArgumentException(
                    "When specifying a value for nextPage, it must already be in the Pages collection.", "nextPage");
            }

            if (CurrentPage == null || CurrentPage.CommitPage())
            {
                pageHistory.Push(CurrentPage);
                CurrentPage = nextPage ?? strategy.GetNextPage(this, CurrentPage);
            }
        }

        public virtual void PreviousPage()
        {
            if (pageHistory.Count > 0)
            {
                if (CurrentPage != null && CurrentPage.RollbackPage())
                {
                    CurrentPage = pageHistory.Pop();
                }
            }
        }

        public virtual void Finish()
        {
            OnFinished(new RoutedEventArgs());
        }

        public virtual void Cancel()
        {
            OnCancelled(new RoutedEventArgs());
        }

        #endregion [Public Methods]

        #region [Dependency Properties]

        #region [BackButtonContent]

        public Object BackButtonContent
        {
            get { return (Object)GetValue(BackButtonContentProperty); }
            set { SetValue(BackButtonContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackButtonContentProperty =
            DependencyProperty.Register("BackButtonContent", typeof(Object), typeof(Wizard), 
                new UIPropertyMetadata(Properties.Resources.BackButtonText));

        #endregion [BackButtonContent]

        #region [NextButtonContent]
        
        public Object NextButtonContent
        {
            get { return (Object)GetValue(NextButtonContentProperty); }
            set { SetValue(NextButtonContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NextButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NextButtonContentProperty =
            DependencyProperty.Register("NextButtonContent", typeof(Object), typeof(Wizard),
                new UIPropertyMetadata(Properties.Resources.NextButtonText));

        #endregion [NextButtonContent]

        #region [FinishButtonContent]

        public Object FinishButtonContent
        {
            get { return (Object)GetValue(FinishButtonContentProperty); }
            set { SetValue(FinishButtonContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FinishButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FinishButtonContentProperty =
            DependencyProperty.Register("FinishButtonContent", typeof(Object), typeof(Wizard),
                new UIPropertyMetadata(Properties.Resources.FinishButtonText));

        #endregion [FinishButtonContent]

        #region [CancelButtonContent]

        public Object CancelButtonContent
        {
            get { return (Object)GetValue(CancelButtonContentProperty); }
            set { SetValue(CancelButtonContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CancelButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CancelButtonContentProperty =
            DependencyProperty.Register("CancelButtonContent", typeof(Object), typeof(Wizard),
                new UIPropertyMetadata(Properties.Resources.CancelButtonText));

        #endregion [CancelButtonContent]

        #region [CurrentPage]
        
        public WizardPage CurrentPage
        {
            get
            {
                return (WizardPage)GetValue(CurrentPageProperty);
            }
            private set
            {
                SetValue(CurrentPagePropertyKey, value);
            }
        }

        private static readonly DependencyPropertyKey CurrentPagePropertyKey =
            DependencyProperty.RegisterReadOnly("CurrentPage", typeof(WizardPage), typeof(Wizard), 
                new UIPropertyMetadata(null, OnCurrentPageChanged, CoerceCurrentPage));

        public static readonly DependencyProperty CurrentPageProperty = CurrentPagePropertyKey.DependencyProperty;

        private static void OnCurrentPageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var wizard = (Wizard)d;
            var oldPage = e.OldValue as WizardPage;
            var newPage = e.NewValue as WizardPage;
            wizard.CurrentPageIndex = wizard.Pages.IndexOf(newPage);

            if (wizard.IsLoaded && newPage != null)
            {
                newPage.InitializePage(oldPage);
            }
            
            UpdateFirstLastPage(wizard);

            wizard.OnCurrentPageChanged(new CurrentPageChangedEventArgs(oldPage, newPage));
        }

        private static object CoerceCurrentPage(DependencyObject d, object basevalue)
        {
            var wizard = (Wizard)d;
            var value = (WizardPage)basevalue;
            
            if (value == null || wizard.Pages.Contains(value))
            {
                return value;
            }

            return DependencyProperty.UnsetValue;
        }

        #endregion [CurrentPage]

        #region [CurrentPageIndex]

        public int CurrentPageIndex
        {
            get
            {
                return (int)GetValue(CurrentPageIndexProperty);
            }
            private set
            {
                SetValue(CurrentPageIndexPropertyKey, value);
            }
        }

        private static readonly DependencyPropertyKey CurrentPageIndexPropertyKey =
            DependencyProperty.RegisterReadOnly("CurrentPageIndex", typeof(int), typeof(Wizard),
            new UIPropertyMetadata(-1), ValidateCurrentPageIndex);

        public static readonly DependencyProperty CurrentPageIndexProperty =
            CurrentPageIndexPropertyKey.DependencyProperty;

        private static bool ValidateCurrentPageIndex(object value)
        {
            return (int)value >= -1;
        }

        #endregion [CurrentPageIndex]

        #region [HasPages]

        public bool HasPages
        {
            get { return (bool)GetValue(HasPagesProperty); }
            private set { SetValue(HasPagesPropertyKey, value); }
        }

        private static readonly DependencyPropertyKey HasPagesPropertyKey =
            DependencyProperty.RegisterReadOnly("HasPages", typeof (bool), typeof (Wizard),
                                                new UIPropertyMetadata(false));

        public static readonly DependencyProperty HasPagesProperty =
            HasPagesPropertyKey.DependencyProperty;

        #endregion [HasPages]

        #region [IsFirstPage]

        public bool IsFirstPage
        {
            get { return (bool)GetValue(IsFirstPageProperty); }
            private set { SetValue(IsFirstPagePropertyKey, value); }
        }

        private static readonly DependencyPropertyKey IsFirstPagePropertyKey =
            DependencyProperty.RegisterReadOnly("IsFirstPage", typeof (bool), typeof (Wizard),
                                                new UIPropertyMetadata(true));

        public static readonly DependencyProperty IsFirstPageProperty =
            IsFirstPagePropertyKey.DependencyProperty;

        #endregion [IsFirstPage]

        #region [IsLastPage]

        public bool IsLastPage
        {
            get { return (bool)GetValue(IsLastPageProperty); }
            private set { SetValue(IsLastPagePropertyKey, value); }
        }

        private static readonly DependencyPropertyKey IsLastPagePropertyKey =
            DependencyProperty.RegisterReadOnly("IsLastPage", typeof (bool), typeof (Wizard),
                                                new UIPropertyMetadata(true));

        public static readonly DependencyProperty IsLastPageProperty =
            IsLastPagePropertyKey.DependencyProperty;

        #endregion [IsLastPage]

        #endregion

        #region [Public Properties]

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Bindable(true)]
        public WizardPageCollection Pages
        {
            get
            {
                return pages;
            }
        }

        public INavigationStrategy NavigationStrategy
        {
            get
            {
                return strategy;
            }
            set
            {
                strategy = value ?? new DefaultNavigationStrategy();
            }
        }

        #endregion [Public Properties]

        #region [Public Events]

        #region [Finished Event]

        public static readonly RoutedEvent FinishedEvent = EventManager.RegisterRoutedEvent(
            "Finished", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (Wizard));

        public event RoutedEventHandler Finished
        {
            add { AddHandler(FinishedEvent, value); }
            remove { RemoveHandler(FinishedEvent, value); }
        }

        #endregion [Finished Event]

        #region [Cancelled Event]

        public static readonly RoutedEvent CancelledEvent = EventManager.RegisterRoutedEvent(
            "Cancelled", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (Wizard));

        public event RoutedEventHandler Cancelled
        {
            add { AddHandler(CancelledEvent, value); }
            remove { RemoveHandler(CancelledEvent, value); }
        }

        #endregion [Cancelled Event]

        #region [CurrentPageChanged Event]

        public static readonly RoutedEvent CurrentPageChangedEvent = EventManager.RegisterRoutedEvent(
            "CurrentPageChanged", RoutingStrategy.Bubble, typeof (EventHandler<CurrentPageChangedEventArgs>), typeof (Wizard));

        public event EventHandler<CurrentPageChangedEventArgs> CurrentPageChanged
        {
            add { AddHandler(CurrentPageChangedEvent, value); }
            remove { RemoveHandler(CurrentPageChangedEvent, value); }
        }

        #endregion [CurrentPageChanged Event]

        #endregion [Public Events]

        #region [Protected Methods]

        protected virtual void OnFinished(RoutedEventArgs args)
        {
            args.RoutedEvent = FinishedEvent;
            RaiseEvent(args);
        }

        protected virtual void OnCancelled(RoutedEventArgs args)
        {
            args.RoutedEvent = CancelledEvent;
            RaiseEvent(args);
        }

        protected virtual void OnCurrentPageChanged(CurrentPageChangedEventArgs args)
        {
            args.RoutedEvent = CurrentPageChangedEvent;
            RaiseEvent(args);
        }

        #endregion [Protected Methods]

        #region [Commands]

        private static void OnBackCommand(Object sender, ExecutedRoutedEventArgs e)
        {
            var wizard = sender as Wizard;
            if (wizard != null)
            {
                wizard.PreviousPage();
            }
        }

        private static void OnBackCommandCanExecute(Object sender, CanExecuteRoutedEventArgs e)
        {
            var wizard = sender as Wizard;
            if (wizard != null)
            {
                e.CanExecute = !wizard.IsFirstPage && wizard.CurrentPage != null && wizard.CurrentPage.AllowBack;
            }
        }

        private static void OnNextCommand(Object sender, ExecutedRoutedEventArgs e)
        {
            var wizard = sender as Wizard;
            if (wizard != null)
            {
                if (e.Parameter == null)
                {
                    wizard.NextPage();                    
                }
                else if (e.Parameter is WizardPage)
                {
                    wizard.NextPage((WizardPage)e.Parameter);
                }
                else
                {
                    var converter = TypeDescriptor.GetConverter(typeof(int));
                    if (converter.CanConvertFrom(e.Parameter.GetType()))
                    {
                        int index = (int)converter.ConvertFrom(e.Parameter);
                        if (index >= 0 && index < wizard.Pages.Count)
                        {
                            wizard.NextPage(wizard.Pages[index]);
                        }
                    }
                }
            }
        }

        private static void OnNextCommandCanExecute(Object sender, CanExecuteRoutedEventArgs e)
        {
            var wizard = sender as Wizard;
            if (wizard != null)
            {
                e.CanExecute = wizard.CurrentPage != null && wizard.CurrentPage.AllowNext;
                if (e.CanExecute && e.Parameter != null)
                {
                    if (e.Parameter is WizardPage)
                    {
                        e.CanExecute &= wizard.Pages.Contains((WizardPage)e.Parameter);
                    }
                    else
                    {
                        var converter = TypeDescriptor.GetConverter(typeof(int));
                        if (converter.CanConvertFrom(e.Parameter.GetType()))
                        {
                            int index = (int)converter.ConvertFrom(e.Parameter);
                            e.CanExecute &= (index >= 0 && index < wizard.Pages.Count);
                        }
                        else
                        {
                            e.CanExecute = false;
                        }
                    }
                }
            }
        }

        private static void OnFinishCommand(object sender, ExecutedRoutedEventArgs e)
        {
            var wizard = sender as Wizard;
            if (wizard != null)
            {
                wizard.Finish();
            }
        }

        private static void OnFinishCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var wizard = sender as Wizard;
            if (wizard != null)
            {
                e.CanExecute = wizard.IsLastPage;
            }
        }

        private static void OnCancelCommand(object sender, ExecutedRoutedEventArgs e)
        {
            var wizard = sender as Wizard;
            if (wizard != null)
            {
                wizard.Cancel();
            }
        }

        private static void OnCancelCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var wizard = sender as Wizard;
            if (wizard != null)
            {
                e.CanExecute = wizard.CurrentPage == null || wizard.CurrentPage.AllowCancel;
            }
        }

        #endregion [Commands]

        #region [Private Methods]

        private void HandlePagesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (Pages.Count == 0)
            {
                CurrentPage = null;
            }
            else if (CurrentPage == null)
            {
                CurrentPage = Pages.FirstOrDefault();
            }

            HasPages = Pages.Count > 0;
            UpdateFirstLastPage(this);

            if (e.Action.In(NotifyCollectionChangedAction.Add, NotifyCollectionChangedAction.Replace))
            {
                foreach (WizardPage wizardPage in e.NewItems)
                {
                    DependencyPropertyDescriptor desc = DependencyPropertyDescriptor.FromProperty(
                        WizardPage.IsFinishPageProperty, typeof (WizardPage));
                    desc.AddValueChanged(wizardPage, OnWizardPageIsFinishChanged);
                }
            }
            else if (e.Action.In(NotifyCollectionChangedAction.Remove, NotifyCollectionChangedAction.Replace))
            {
                foreach (WizardPage wizardPage in e.OldItems)
                {
                    DependencyPropertyDescriptor desc = DependencyPropertyDescriptor.FromProperty(
                        WizardPage.IsFinishPageProperty, typeof(WizardPage));
                    desc.RemoveValueChanged(wizardPage, OnWizardPageIsFinishChanged);
                }
            }
        }

        private void OnWizardPageIsFinishChanged(object sender, EventArgs e)
        {
            UpdateFirstLastPage(this);
            CommandManager.InvalidateRequerySuggested();
        }

        private static void UpdateFirstLastPage(Wizard wizard)
        {
            wizard.IsFirstPage = wizard.CurrentPage == wizard.Pages.FirstOrDefault();
            wizard.IsLastPage = wizard.CurrentPage == wizard.Pages.LastOrDefault() ||
                                (wizard.CurrentPage != null && wizard.CurrentPage.IsFinishPage);
        }

        #endregion [Private Methods]

        #region [Private Fields]

        private readonly WizardPageCollection pages;

        private readonly Stack<WizardPage> pageHistory = new Stack<WizardPage>();

        private INavigationStrategy strategy = new DefaultNavigationStrategy(); 

        #endregion [Private Fields]

        #region [Implementation of IAddChild]

        /// <summary>
        /// Adds a child object. 
        /// </summary>
        /// <param name="value">The child object to add.</param>
        void IAddChild.AddChild(object value)
        {
            var page = value as WizardPage;
            if (page == null)
                throw new ArgumentException("The object must be derived from WizardPage", "value");
            
            Pages.Add(page);
        }

        /// <summary>
        /// Adds the text content of a node to the object. 
        /// </summary>
        /// <param name="text">The text to add to the object.</param>
        void IAddChild.AddText(string text)
        {
            throw new NotImplementedException();
        }

        #endregion [Implementation of IAddChild]
    }
}
