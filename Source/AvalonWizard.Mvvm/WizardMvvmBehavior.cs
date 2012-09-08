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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace AvalonWizard.Mvvm
{
    /// <summary>
    /// Provides properties to simplify implementation of MVVM pattern.
    /// </summary>
    public class WizardMvvmBehavior : Behavior<Wizard>
    {
        private readonly IDictionary<Object, WizardPage> pageCache = 
            new Dictionary<Object, WizardPage>(); 

        #region [Dependency Properties]

        #region [ItemSource]

        /// <summary>
        /// Gets or sets the items source.
        /// </summary>
        /// <value>The items source.</value>
        public Object ItemsSource
        {
            get { return GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        /// Identifies <see cref="ItemsSource"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(Object), typeof(WizardMvvmBehavior), 
                new UIPropertyMetadata(null, OnItemsSourceChanged));
        
        #endregion

        #region [ItemTemplate]

        /// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>The item template.</value>
        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        /// <summary>
        /// Identifies <see cref="ItemTemplate"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(WizardMvvmBehavior), 
                new UIPropertyMetadata(null));
        
        #endregion

        #region [ItemTemplateSelector]

        /// <summary>
        /// Gets or sets the item template selector.
        /// </summary>
        /// <value>The item template selector.</value>
        public DataTemplateSelector ItemTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ItemTemplateSelectorProperty); }
            set { SetValue(ItemTemplateSelectorProperty, value); }
        }

        /// <summary>
        /// Identifies <see cref="ItemTemplateSelector"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ItemTemplateSelectorProperty =
            DependencyProperty.Register("ItemTemplateSelector", typeof(DataTemplateSelector), typeof(WizardMvvmBehavior), 
                new UIPropertyMetadata(null));
        
        #endregion

        #region [Controller]

        /// <summary>
        /// Gets or sets the controller.
        /// The controller can be used to navigate between pages.
        /// </summary>
        /// <value>The controller.</value>
        public IWizardController Controller
        {
            get { return (IWizardController)GetValue(ControllerProperty); }
            set { SetValue(ControllerProperty, value); }
        }

        /// <summary>
        /// Identifies <see cref="Controller"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty ControllerProperty = DependencyProperty.Register(
            "Controller", typeof(IWizardController), typeof(WizardMvvmBehavior), 
            new UIPropertyMetadata(null, OnControllerChanged));

        #endregion

        #endregion

        #region [Properties]

        private BindingBase headerBinding;

        /// <summary>
        /// Gets or sets the header binding.
        /// </summary>
        /// <value>The header binding.</value>
        public BindingBase HeaderBinding
        {
            get { return headerBinding; }
            set
            {
                headerBinding = value;
                SetPagePropertyBinding(value, WizardPage.HeaderProperty);
            }
        }

        private BindingBase subtitleBinding;

        /// <summary>
        /// Gets or sets the subtitle binding.
        /// </summary>
        /// <value>The subtitle binding.</value>
        public BindingBase SubtitleBinding
        {
            get { return subtitleBinding; }
            set
            {
                subtitleBinding = value;
                SetPagePropertyBinding(value, Wizard97.SubtitleProperty);
            }
        }

        private BindingBase iconBinding;

        /// <summary>
        /// Gets or sets the icon binding.
        /// </summary>
        /// <value>The icon binding.</value>
        public BindingBase IconBinding
        {
            get { return iconBinding; }
            set
            {
                iconBinding = value;
                SetPagePropertyBinding(value, Wizard97.IconProperty);
            }
        }
        
        private BindingBase isFinishPageBinding;

        /// <summary>
        /// Gets or sets the binding to the property indicating whether the page is finish one.
        /// </summary>
        public BindingBase IsFinishPageBinding
        {
            get { return isFinishPageBinding; }
            set
            {
                isFinishPageBinding = value;
                SetPagePropertyBinding(value, WizardPage.IsFinishPageProperty);
            }
        }

        private BindingBase allowCancelBinding;

        /// <summary>
        /// Gets or sets the binding to the property indicating whether to allow cancel the wizard.
        /// </summary>
        public BindingBase AllowCancelBinding
        {
            get { return allowCancelBinding; }
            set
            {
                allowCancelBinding = value;
                SetPagePropertyBinding(value, WizardPage.AllowCancelProperty);
            }
        }

        private BindingBase allowBackBinding;

        /// <summary>
        /// Gets or sets the binding to the property indicating whether to allow going back.
        /// </summary>
        public BindingBase AllowBackBinding
        {
            get { return allowBackBinding; }
            set
            {
                allowBackBinding = value;
                SetPagePropertyBinding(value, WizardPage.AllowBackProperty);
            }
        }

        private BindingBase allowNextBinding;

        /// <summary>
        /// Gets or sets the binding to the property indicating whether to allow going to the next page.
        /// </summary>
        public BindingBase AllowNextBinding
        {
            get { return allowNextBinding; }
            set
            {
                allowNextBinding = value;
                SetPagePropertyBinding(value, WizardPage.AllowNextProperty);
            }
        }

        private BindingBase allowFinishBinding;

        /// <summary>
        /// Gets or sets the binding to the property indicating whether to allow finish the wizard.
        /// </summary>
        public BindingBase AllowFinishBinding
        {
            get { return allowFinishBinding; }
            set
            {
                allowFinishBinding = value;
                SetPagePropertyBinding(value, WizardPage.AllowFinishProperty);
            }
        }

        private BindingBase showCancelBinding;

        /// <summary>
        /// Gets or sets the binding to the property indicating whether to show Cancel button.
        /// </summary>
        public BindingBase ShowCancelBinding
        {
            get { return showCancelBinding; }
            set
            {
                showCancelBinding = value;
                SetPagePropertyBinding(value, WizardPage.ShowCancelProperty);
            }
        }

        private BindingBase showBackBinding;

        /// <summary>
        /// Gets or sets the binding to the property indicating whether to show Back button.
        /// </summary>
        public BindingBase ShowBackBinding
        {
            get { return showBackBinding; }
            set
            {
                showBackBinding = value;
                SetPagePropertyBinding(value, WizardPage.ShowBackProperty);
            }
        }

        private BindingBase showNextBinding;

        /// <summary>
        /// Gets or sets the binding to the property indicating whether to show Next button.
        /// </summary>
        public BindingBase ShowNextBinding
        {
            get { return showNextBinding; }
            set
            {
                showNextBinding = value;
                SetPagePropertyBinding(value, WizardPage.ShowNextProperty);
            }
        }

        private BindingBase nextPageBinding;

        /// <summary>
        /// Gets or sets the next page binding.
        /// </summary>
        /// <value>The next page binding.</value>
        public BindingBase NextPageBinding
        {
            get { return nextPageBinding; }
            set
            {
                nextPageBinding = value;
                SetPageBehaviorPropertyBinding(value, WizardPageMvvmBehavior.NextPageProperty);
            }
        }

        private BindingBase initializeCommandBinding;

        /// <summary>
        /// Gets or sets the initialize command binding.
        /// </summary>
        /// <value>The initialize command binding.</value>
        public BindingBase InitializeCommandBinding
        {
            get { return initializeCommandBinding; }
            set
            {
                initializeCommandBinding = value;
                SetPageBehaviorPropertyBinding(value, WizardPageMvvmBehavior.InitializeCommandProperty);
            }
        }

        private BindingBase commitCommandBinding;

        /// <summary>
        /// Gets or sets the commit command binding.
        /// </summary>
        /// <value>The commit command binding.</value>
        public BindingBase CommitCommandBinding
        {
            get { return commitCommandBinding; }
            set
            {
                commitCommandBinding = value;
                SetPageBehaviorPropertyBinding(value, WizardPageMvvmBehavior.CommitCommandProperty);
            }
        }

        private BindingBase rollbackCommandBinding;

        /// <summary>
        /// Gets or sets the rollback command binding.
        /// </summary>
        /// <value>The rollback command binding.</value>
        public BindingBase RollbackCommandBinding
        {
            get { return rollbackCommandBinding; }
            set
            {
                rollbackCommandBinding = value;
                SetPageBehaviorPropertyBinding(value, WizardPageMvvmBehavior.RollbackCommandProperty);
            }
        }

        #endregion

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = (WizardMvvmBehavior)d;
            var items = e.NewValue as IEnumerable;
            behavior.GeneratePages(items);
        }

        private void GeneratePages(IEnumerable newPageViewModels)
        {
            if (AssociatedObject == null)
                return;

            AssociatedObject.Pages.Clear();
            if (newPageViewModels != null)
            {
                foreach (Object pageViewModel in newPageViewModels)
                {
                    AssociatedObject.Pages.Add(GeneratePage(pageViewModel));
                }
            }
        }

        private WizardPage GeneratePage(object pageViewModel)
        {
            var page = pageViewModel as WizardPage;
            if (page == null)
            {
                if (!pageCache.TryGetValue(pageViewModel, out page))
                {
                    page = new WizardPage
                        {
                            DataContext = pageViewModel,
                            Content = pageViewModel,
                        };
                    pageCache.Add(pageViewModel, page);
                }
                ApplyBindings(page, pageViewModel);
            }
            else
            {
                page.DataContext = pageViewModel;
            }
            return page;
        }

        private void ApplyBindings(WizardPage page, Object pageViewModel)
        {
            BindThis(page, ContentControl.ContentTemplateProperty, "ItemTemplate");
            BindThis(page, ContentControl.ContentTemplateSelectorProperty, "ItemTemplateSelector");

            ApplyBindings(page, pageViewModel as IWizardPageViewModel);
        }

        private void ApplyBindings(WizardPage page, IWizardPageViewModel pageViewModel)
        {
            if (pageViewModel == null)
                return;

            SetPagePropertyBinding(page, WizardPage.HeaderProperty, HeaderBinding);
            SetPagePropertyBinding(page, Wizard97.SubtitleProperty, SubtitleBinding);
            SetPagePropertyBinding(page, Wizard97.IconProperty, IconBinding);
            SetPagePropertyBinding(page, WizardPage.IsFinishPageProperty, IsFinishPageBinding);
            SetPagePropertyBinding(page, WizardPage.AllowBackProperty, AllowBackBinding);
            SetPagePropertyBinding(page, WizardPage.AllowCancelProperty, AllowCancelBinding);
            SetPagePropertyBinding(page, WizardPage.AllowFinishProperty, AllowFinishBinding);
            SetPagePropertyBinding(page, WizardPage.AllowNextProperty, AllowNextBinding);
            SetPagePropertyBinding(page, WizardPage.ShowBackProperty, ShowBackBinding);
            SetPagePropertyBinding(page, WizardPage.ShowCancelProperty, ShowCancelBinding);
            SetPagePropertyBinding(page, WizardPage.ShowNextProperty, ShowNextBinding);

            SetPageBehaviorPropertyBinding(page, WizardPageMvvmBehavior.InitializeCommandProperty, InitializeCommandBinding);
            SetPageBehaviorPropertyBinding(page, WizardPageMvvmBehavior.CommitCommandProperty, CommitCommandBinding);
            SetPageBehaviorPropertyBinding(page, WizardPageMvvmBehavior.RollbackCommandProperty, RollbackCommandBinding);
            SetPageBehaviorPropertyBinding(page, WizardPageMvvmBehavior.NextPageProperty, NextPageBinding);
        }

        private static WizardPageMvvmBehavior EnsurePageBehavior(WizardPage page)
        {
            var behaviors = Interaction.GetBehaviors(page);
            var pageBehavior = behaviors.OfType<WizardPageMvvmBehavior>().FirstOrDefault();
            if (pageBehavior == null)
            {
                pageBehavior = new WizardPageMvvmBehavior();
                behaviors.Add(pageBehavior);
            }
            return pageBehavior;
        }

        private void BindThis(WizardPage page, DependencyProperty property, String path)
        {
            page.SetBinding(property, new Binding(path) {Source = this, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged});
        }

        private void BindDefaultViewModel(WizardPage page, DependencyProperty property, IWizardPageViewModel source)
        {
            page.SetBinding(property, new Binding(property.Name) {Source = source, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged});
        }

        private void BindPageBehavior(WizardPageMvvmBehavior behavior, DependencyProperty property, IWizardPageViewModel source)
        {
            BindingOperations.SetBinding(behavior, property, new Binding(property.Name) {Source = source, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged});
        }

        private void SetPagePropertyBinding(BindingBase binding, DependencyProperty property)
        {
            if (AssociatedObject == null)
                return;

            foreach (var page in AssociatedObject.Pages)
            {
                SetPagePropertyBinding(page, property, binding);
            }
        }

        private void SetPagePropertyBinding(WizardPage page, DependencyProperty property, BindingBase binding)
        {
            if (binding == null)
            {
                var viewModel = page.DataContext as IWizardPageViewModel;
                if (viewModel != null)
                {
                    BindDefaultViewModel(page, property, viewModel);
                }
                else
                {
                    BindingOperations.ClearBinding(page, property);
                }
            }
            else
            {
                page.SetBinding(property, binding);
            }
        }

        private void SetPageBehaviorPropertyBinding(BindingBase binding, DependencyProperty property)
        {
            if (AssociatedObject == null)
                return;

            foreach (var page in AssociatedObject.Pages)
            {
                SetPageBehaviorPropertyBinding(page, property, binding);
            }
        }

        private void SetPageBehaviorPropertyBinding(WizardPage page, DependencyProperty property, BindingBase binding)
        {
            var behavior = EnsurePageBehavior(page);
            if (binding == null)
            {
                var viewModel = page.DataContext as IWizardPageViewModel;
                if (viewModel != null)
                {
                    BindPageBehavior(behavior, property, viewModel);
                }
                else
                {
                    BindingOperations.ClearBinding(behavior, property);
                }
            }
            else
            {
                BindingOperations.SetBinding(behavior, property, binding);
            }
        }

        private static void OnControllerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = (WizardMvvmBehavior)d;

            var oldController = e.OldValue as IWizardController;
            if (oldController != null)
            {
                oldController.NavigationRequested -= behavior.OnNavigationRequested;
                oldController.FinishRequested -= behavior.OnFinishRequested;
                oldController.CancelRequested -= behavior.OnCancelRequested;
            }

            var newController = e.NewValue as IWizardController;
            if (newController != null)
            {
                newController.CancelRequested += behavior.OnCancelRequested;
                newController.FinishRequested += behavior.OnFinishRequested;
                newController.NavigationRequested += behavior.OnNavigationRequested;
            }
        }

        private void OnNavigationRequested(object sender, WizardNavigationEventArgs e)
        {
            if (AssociatedObject == null)
                return;

            if (e.Direction == WizardNavigationDirection.Back)
            {
                AssociatedObject.PreviousPage();
            }
            else
            {
                if (e.Target == null)
                {
                    AssociatedObject.NextPage();
                }
                else if (e.Target is Int32)
                {
                    AssociatedObject.NextPageByIndex((int) e.Target);
                }
                else if (e.Target is String)
                {
                    AssociatedObject.NextPageByName((String) e.Target);
                }
                else if (e.Target is WizardPage)
                {
                    AssociatedObject.NextPage((WizardPage)e.Target);
                }
                else
                {
                    var page = AssociatedObject.Pages.FirstOrDefault(p => p.DataContext == e.Target);
                    if (page != null)
                        AssociatedObject.NextPage(page);
                }
            }
        }

        private void OnFinishRequested(object sender, EventArgs e)
        {
            if (AssociatedObject != null)
                AssociatedObject.Finish();
        }

        private void OnCancelRequested(object sender, EventArgs e)
        {
            if (AssociatedObject != null)
                AssociatedObject.Cancel();
        }

        #region Behavior<Wizard> overrides.

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            base.OnAttached();

            GeneratePages(ItemsSource as IEnumerable);
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            
            pageCache.Clear();
        }

        #endregion
    }
}
