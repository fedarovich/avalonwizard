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
            if (wizard.Content.Collection.Count == 0)
            {
                AddPage(wizard);
                return;
            }
            using (ModelEditingScope changes = wizard.BeginEdit(Resources.InsertPageText))
            {
                ModelItem newPage = ModelFactory.CreateItem(
                    wizard.Context,
                    Types.WizardPage.TypeId,
                    CreateOptions.None);

                int currentPageIndex = (int)wizard.Properties[Types.Designer.PageIndexProperty].ComputedValue;
                wizard.Content.Collection.Insert(currentPageIndex, newPage);
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
