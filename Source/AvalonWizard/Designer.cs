using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace AvalonWizard
{
    /// <summary>
    /// Provides attached properties for design-time support of wizard.
    /// </summary>
    public class Designer : DependencyObject
    {
        /// <summary>
        /// Gets the design-time page index.
        /// </summary>
        /// <param name="obj">The <see cref="Wizard"/> instance.</param>
        /// <returns>Design-time page index.</returns>
        /// <seealso cref="SetPageIndex"/>
        /// <seealso cref="PageIndexProperty"/>
        [AttachedPropertyBrowsableForType(typeof(Wizard))]
        public static int GetPageIndex(DependencyObject obj)
        {
            return (int)obj.GetValue(PageIndexProperty);
        }

        /// <summary>
        /// Sets the design-time page index.
        /// </summary>
        /// <param name="obj">The <see cref="Wizard"/> instance.</param>
        /// <param name="value">Design-time page index.</param>
        /// <seealso cref="GetPageIndex"/>
        /// <seealso cref="PageIndexProperty"/>
        public static void SetPageIndex(DependencyObject obj, int value)
        {
            obj.SetValue(PageIndexProperty, value);
        }

        /// <summary>
        /// Identifies <c>PageIndex</c> attached property.
        /// </summary>
        /// <seealso cref="GetPageIndex"/>
        /// <seealso cref="SetPageIndex"/>
        public static readonly DependencyProperty PageIndexProperty =
            DependencyProperty.RegisterAttached("PageIndex", typeof(int), typeof(Designer), 
                new UIPropertyMetadata(0, OnPageIndexChanged, OnCoercePageIndex), OnValidatePageIndex);

        private static bool OnValidatePageIndex(object value)
        {
            return (int)value >= -1;
        }

        private static object OnCoercePageIndex(DependencyObject d, object baseValue)
        {
            var wizard = (d as Wizard);
            if (wizard == null)
            {
                return baseValue;
            }

            int index = (int)baseValue;
            if (index < -1)
            {
                return -1;
            }
            if (index >= wizard.Pages.Count)
            {
                return wizard.Pages.Count - 1;
            }
            return baseValue;
        }

        private static void OnPageIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var wizard = (d as Wizard);
            if (wizard != null)
            {
                if (DesignerProperties.GetIsInDesignMode(wizard))
                {
                    if (wizard.IsLoaded)
                    {
                        wizard.NextPageByIndex((int)e.NewValue);
                    }
                    else
                    {
                        DelayedSetter.Create(wizard);
                    }
                }
            }
        }

        private class DelayedSetter
        {
            public static void Create(Wizard wizard)
            {
                var delayedSetter = new DelayedSetter();
                wizard.Loaded += delayedSetter.OnWizardLoaded;
            }

            private void OnWizardLoaded(object sender, RoutedEventArgs e)
            {
                var wizard = (Wizard)sender;
                wizard.NextPageByIndex(GetPageIndex(wizard));
                wizard.Loaded -= OnWizardLoaded;
            }
        }
    }
}
