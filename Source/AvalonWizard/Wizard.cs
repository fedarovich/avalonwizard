using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AvalonWizard
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:AvalonWizard"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:AvalonWizard;assembly=AvalonWizard"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:Wizard/>
    ///
    /// </summary>
    public class Wizard : Selector
    {
        public Wizard()
        {
            //navigationManager = new NavigationManager(this);
        }

        static Wizard()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Wizard), new FrameworkPropertyMetadata(typeof(Wizard)));
            
            var backBinding = new CommandBinding(NavigationCommands.PreviousPage,
                OnBackCommand,
                OnBackCommandCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(Wizard), backBinding);

            var nextBinding = new CommandBinding(NavigationCommands.NextPage,
                OnNextCommand,
                OnNextCommandCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(Wizard), nextBinding);
        }

        #region Commands

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
                e.CanExecute = true;
            }
        }

        private static void OnNextCommand(Object sender, ExecutedRoutedEventArgs e)
        {
            var wizard = sender as Wizard;
            if (wizard != null)
            {
                wizard.NextPage();
            }
        }

        private static void OnNextCommandCanExecute(Object sender, CanExecuteRoutedEventArgs e)
        {
            var wizard = sender as Wizard;
            if (wizard != null)
            {
                e.CanExecute = true;
            }
        }

        #endregion

        public virtual void NextPage()
        {
            NextPage(null);
        }

        public virtual void NextPage(WizardPage nextPage)
        {
            if (nextPage == null)
            {
                if (SelectedPage.IsFinishPage || SelectedIndex == Items.Count - 1)
                {
                    // TODO: Raise Finish event
                    return;
                }
            }
            else if (!Items.Contains(nextPage))
            {
                throw new ArgumentException(
                    "When specifying a value for nextPage, it must already be in the Pages collection.", "nextPage");
            }

            if (SelectedPage.CommitPage())
            {
                //pageHistory.Push(SelectedPage);
                if (nextPage != null)
                    SelectedItem = nextPage;
                else if (SelectedPage.NextPage != null)
                    SelectedItem = SelectedPage.NextPage;
                else
                    SelectedItem = Items[Items.IndexOf(SelectedPage) + 1];
            }
        }

        public virtual void PreviousPage()
        {
            
        }

        public WizardPage SelectedPage
        {
            get
            {
                if (SelectedItem == null)
                {
                    return null;
                }

                WizardPage page = SelectedItem as WizardPage;
                if (page == null)
                {
                    page = ItemContainerGenerator.ContainerFromIndex(SelectedIndex) as WizardPage;
                }
                return page;
            }
        }

        #region [Dependency Properties]

        public Object BackButtonContent
        {
            get { return (Object)GetValue(BackButtonContentProperty); }
            set { SetValue(BackButtonContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackButtonContentProperty =
            DependencyProperty.Register("BackButtonContent", typeof(Object), typeof(Wizard), 
                new UIPropertyMetadata(Properties.Resources.BackButtonText));



        public Object NextButtonContent
        {
            get { return (Object)GetValue(NextButtonContentProperty); }
            set { SetValue(NextButtonContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NextButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NextButtonContentProperty =
            DependencyProperty.Register("NextButtonContent", typeof(Object), typeof(Wizard),
                new UIPropertyMetadata(Properties.Resources.NextButtonText));




        public Object FinishButtonContent
        {
            get { return (Object)GetValue(FinishButtonContentProperty); }
            set { SetValue(FinishButtonContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FinishButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FinishButtonContentProperty =
            DependencyProperty.Register("FinishButtonContent", typeof(Object), typeof(Wizard),
                new UIPropertyMetadata(Properties.Resources.FinishButtonText));




        public Object CancelButtonContent
        {
            get { return (Object)GetValue(CancelButtonContentProperty); }
            set { SetValue(CancelButtonContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CancelButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CancelButtonContentProperty =
            DependencyProperty.Register("CancelButtonContent", typeof(Object), typeof(Wizard),
                new UIPropertyMetadata(Properties.Resources.CancelButtonText));

        #endregion

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new WizardPage();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is WizardPage;
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            base.ItemContainerGenerator.StatusChanged += OnGeneratorStatusChanged;
        }

        private void OnGeneratorStatusChanged(object sender, EventArgs e)
        {
            if (base.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
            {
                if (base.HasItems && (base.SelectedIndex < 0))
                {
                    base.SelectedIndex = 0;
                }
                //this.UpdateSelectedContent();
            }
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
        }


        //private readonly NavigationManager navigationManager;
    }
}
