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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AvalonWizard.Design.Properties;
using Microsoft.Windows.Design.Model;

namespace AvalonWizard.Design
{
    internal static class DesignerOperations
    {
        #region [Navigation]

        internal static void GoToFirstPage(ModelItem wizard)
        {
            using (ModelEditingScope changes = wizard.BeginEdit(Resources.FirstPageText))
            {
                SetCurrentPageIndex(wizard, 0);
                changes.Complete();
            }
        }

        internal static bool CanGoToFirstPage(ModelItem wizard)
        {
            return wizard.Content.Collection.Count > 0 && GetCurrentPageIndex(wizard) > 0;
        }

        internal static void GoToPreviousPage(ModelItem wizard)
        {
            using (ModelEditingScope changes = wizard.BeginEdit(Resources.PreviousPageText))
            {
                var pageIndex = GetCurrentPageIndex(wizard);
                SetCurrentPageIndex(wizard, pageIndex - 1);
                changes.Complete();
            }
        }

        internal static bool CanGoToPreviousPage(ModelItem wizard)
        {
            return wizard.Content.Collection.Count > 0 && GetCurrentPageIndex(wizard) > 0;
        }

        internal static void GoToNextPage(ModelItem wizard)
        {
            using (ModelEditingScope changes = wizard.BeginEdit(Resources.NextPageText))
            {
                var pageIndex = GetCurrentPageIndex(wizard);
                SetCurrentPageIndex(wizard, pageIndex + 1);
                changes.Complete();
            }
        }

        internal static bool CanGoToNextPage(ModelItem wizard)
        {
            int pageCount = wizard.Content.Collection.Count;
            return (pageCount > 0) && (GetCurrentPageIndex(wizard) < pageCount - 1);
        }

        internal static void GoToLastPage(ModelItem wizard)
        {
            using (ModelEditingScope changes = wizard.BeginEdit(Resources.LastPageText))
            {
                int pageCount = wizard.Content.Collection.Count;
                SetCurrentPageIndex(wizard, pageCount - 1);
                changes.Complete();
            }
        }

        internal static bool CanGoToLastPage(ModelItem wizard)
        {
            int pageCount = wizard.Content.Collection.Count;
            return (pageCount > 0) && (GetCurrentPageIndex(wizard) < pageCount - 1);
        }

        #endregion [Navigation]

        #region [Editing]

        internal static void AddPage(ModelItem wizard)
        {
            using (ModelEditingScope changes = wizard.BeginEdit(Resources.AddPageText))
            {
                ModelItem newPage = ModelFactory.CreateItem(
                    wizard.Context,
                    Types.WizardPage.TypeId,
                    CreateOptions.None);

                wizard.Content.Collection.Add(newPage);
                changes.Complete();
            }
            GoToLastPage(wizard);
        }

        internal static void InsertPage(ModelItem wizard)
        {
            using (ModelEditingScope changes = wizard.BeginEdit(Resources.InsertPageText))
            {
                ModelItem newPage = ModelFactory.CreateItem(
                    wizard.Context,
                    Types.WizardPage.TypeId,
                    CreateOptions.None);

                var currentPageIndex = (int)wizard.Properties[Types.Designer.PageIndexProperty].ComputedValue;
                if (currentPageIndex < 0)
                {
                    wizard.Content.Collection.Add(newPage);
                }
                else
                {
                    wizard.Content.Collection.Insert(currentPageIndex, newPage);
                }
                wizard.Properties[Types.Designer.PageIndexProperty].SetValue(currentPageIndex);
                changes.Complete();
            }
        }

        internal static void RemovePage(ModelItem wizard)
        {
            using (ModelEditingScope changes = wizard.BeginEdit(Resources.RemovePageText))
            {
                int count = wizard.Content.Collection.Count;
                int currentPageIndex = (int)wizard.Properties[Types.Designer.PageIndexProperty].ComputedValue;
                wizard.Content.Collection.RemoveAt(currentPageIndex);
                wizard.Properties[Types.Designer.PageIndexProperty].SetValue(
                    Math.Min(currentPageIndex, count - 2));
                changes.Complete();
            }
        }

        internal static bool CanRemovePage(ModelItem wizard)
        {
            return wizard.Content.Collection.Count > 0;
        }

        #endregion [Editing]

        internal static int GetCurrentPageIndex(ModelItem wizard)
        {
            return (int)wizard.Properties[Types.Designer.PageIndexProperty].ComputedValue;
        }

        internal static void SetCurrentPageIndex(ModelItem wizard, int index)
        {
            wizard.Properties[Types.Designer.PageIndexProperty].SetValue(index);
        }
    }
}
