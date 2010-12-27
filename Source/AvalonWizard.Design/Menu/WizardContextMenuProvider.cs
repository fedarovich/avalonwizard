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
using AvalonWizard.Design.Properties;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;

namespace AvalonWizard.Design.Menu
{
    internal class WizardContextMenuProvider : PrimarySelectionContextMenuProvider
    {
        public WizardContextMenuProvider()
        {
            MenuGroup editGroup = InitEditMenuGroup();
            MenuGroup navigationGroup = InitNavigationMenuGroup();

            MenuGroup pagesGroup = new MenuGroup("WizardPagesGroup", Resources.PagesMenuGroup);
            pagesGroup.HasDropDown = true;

            this.Items.Add(editGroup);
            this.Items.Add(navigationGroup);

            UpdateItemStatus += OnUpdateItemStatus;
        }

        private MenuGroup InitEditMenuGroup()
        {
            addPageMenuAction = new MenuAction(Resources.AddPageText);
            addPageMenuAction.Execute += OnAddPage;
            addPageMenuAction.ImageUri = ResourceHelper.GetImageUri("AddPage.png");

            insertPageMenuAction = new MenuAction(Resources.InsertPageText);
            insertPageMenuAction.Execute += OnInsertPage;
            insertPageMenuAction.ImageUri = ResourceHelper.GetImageUri("InsertPage.png");

            removePageMenuAction = new MenuAction(Resources.RemovePageText);
            removePageMenuAction.Execute += OnRemovePage;
            removePageMenuAction.ImageUri = ResourceHelper.GetImageUri("RemovePage.png");

            MenuGroup editGroup = new MenuGroup("WizardPagesEditGroup");
            editGroup.Items.Add(addPageMenuAction);
            editGroup.Items.Add(insertPageMenuAction);
            editGroup.Items.Add(removePageMenuAction);
            return editGroup;
        }

        private MenuGroup InitNavigationMenuGroup()
        {
            firstPageMenuAction = new MenuAction(Resources.FirstPageText);
            firstPageMenuAction.Execute += OnGoToFirstPage;
            firstPageMenuAction.ImageUri = ResourceHelper.GetImageUri("GoToFirstPage.png");

            previousPageMenuAction = new MenuAction(Resources.PreviousPageText);
            previousPageMenuAction.Execute += OnGoToPreviousPage;
            previousPageMenuAction.ImageUri = ResourceHelper.GetImageUri("GoToPreviousPage.png");

            nextPageMenuAction = new MenuAction(Resources.NextPageText);
            nextPageMenuAction.Execute += OnGoToNextPage;
            nextPageMenuAction.ImageUri = ResourceHelper.GetImageUri("GoToNextPage.png");

            lastPageMenuAction = new MenuAction(Resources.LastPageText);
            lastPageMenuAction.Execute += OnGoToLastPage;
            lastPageMenuAction.ImageUri = ResourceHelper.GetImageUri("GoToLastPage.png");

            MenuGroup navigationGroup = new MenuGroup("WizardPagesNavigationGroup");
            navigationGroup.Items.Add(firstPageMenuAction);
            navigationGroup.Items.Add(previousPageMenuAction);
            navigationGroup.Items.Add(nextPageMenuAction);
            navigationGroup.Items.Add(lastPageMenuAction);
            return navigationGroup;
        }

        private void OnAddPage(object sender, MenuActionEventArgs e)
        {
            ModelItem wizard = GetWizard(e.Selection.PrimarySelection);
            if (wizard != null)
            {
                DesignerOperations.AddPage(wizard);
            }
        }

        private void OnInsertPage(object sender, MenuActionEventArgs e)
        {
            ModelItem wizard = GetWizard(e.Selection.PrimarySelection);
            if (wizard != null)
            {
                DesignerOperations.InsertPage(wizard);
            }
        }

        private void OnRemovePage(object sender, MenuActionEventArgs e)
        {
            ModelItem wizard = GetWizard(e.Selection.PrimarySelection);
            if (wizard != null)
            {
                DesignerOperations.RemovePage(wizard);
            }
        }

        private void OnGoToFirstPage(object sender, MenuActionEventArgs e)
        {
            ModelItem wizard = GetWizard(e.Selection.PrimarySelection);
            if (wizard != null)
            {
                DesignerOperations.GoToFirstPage(wizard);
            }
        }

        private void OnGoToPreviousPage(object sender, MenuActionEventArgs e)
        {
            ModelItem wizard = GetWizard(e.Selection.PrimarySelection);
            if (wizard != null)
            {
                DesignerOperations.GoToPreviousPage(wizard);
            }
        }

        private void OnGoToNextPage(object sender, MenuActionEventArgs e)
        {
            ModelItem wizard = GetWizard(e.Selection.PrimarySelection);
            if (wizard != null)
            {
                DesignerOperations.GoToNextPage(wizard);
            }
        }

        private void OnGoToLastPage(object sender, MenuActionEventArgs e)
        {
            ModelItem wizard = GetWizard(e.Selection.PrimarySelection);
            if (wizard != null)
            {
                DesignerOperations.GoToLastPage(wizard);
            }
        }

        private void OnUpdateItemStatus(object sender, MenuActionEventArgs e)
        {
            if (e.Selection.SelectionCount == 1 && e.Selection.PrimarySelection.IsItemOfType(Types.Wizard.TypeId))
            {
                addPageMenuAction.Visible = true;
                insertPageMenuAction.Visible = true;
                removePageMenuAction.Visible = true;
                nextPageMenuAction.Visible = true;
                previousPageMenuAction.Visible = true;

                ModelItem wizard = GetWizard(e.Selection.PrimarySelection);

                addPageMenuAction.Enabled = true;
                insertPageMenuAction.Enabled = true;
                removePageMenuAction.Enabled = DesignerOperations.CanRemovePage(wizard);
                
                firstPageMenuAction.Enabled = DesignerOperations.CanGoToFirstPage(wizard);
                previousPageMenuAction.Enabled = DesignerOperations.CanGoToPreviousPage(wizard);
                nextPageMenuAction.Enabled = DesignerOperations.CanGoToNextPage(wizard);
                lastPageMenuAction.Enabled = DesignerOperations.CanGoToLastPage(wizard);
            }
            else
            {
                addPageMenuAction.Visible = false;
                insertPageMenuAction.Visible = false;
                removePageMenuAction.Visible = false;
                nextPageMenuAction.Visible = false;
                previousPageMenuAction.Visible = false;
            }
        }

        private ModelItem GetWizard(ModelItem primarySelection)
        {
            if (primarySelection.IsItemOfType(Types.Wizard.TypeId))
            {
                return primarySelection;
            }
            return null;
        }

        private MenuAction addPageMenuAction;
        private MenuAction insertPageMenuAction;
        private MenuAction removePageMenuAction;

        private MenuAction firstPageMenuAction;
        private MenuAction previousPageMenuAction;
        private MenuAction nextPageMenuAction;
        private MenuAction lastPageMenuAction;
    }
}
