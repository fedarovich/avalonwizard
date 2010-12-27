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
using System.Windows;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;

namespace AvalonWizard.Design.Adorners
{
    internal class WizardAdornerProvider : PrimarySelectionAdornerProvider
    {
        private readonly WizardAdornerView adornerView = new WizardAdornerView();
        private AdornerPanel adornerPanel;

        protected override void Activate(ModelItem item)
        {
            EnsureAdornerPanelExists();
            AdornerPanel.SetAdornerHorizontalAlignment(adornerView, AdornerHorizontalAlignment.Left);
            AdornerPanel.SetAdornerVerticalAlignment(adornerView, AdornerVerticalAlignment.OutsideTop);
            AdornerPanel.SetAdornerMargin(adornerView, new Thickness(0, 0, 0, 20));

            adornerView.DataContext = new WizardAdornerViewModel(item);

            base.Activate(item);
        }

        protected override void Deactivate()
        {
            var viewModel = adornerView.DataContext as IDisposable;
            if (viewModel != null)
            {
                viewModel.Dispose();
            }
            adornerView.DataContext = null;

            base.Deactivate();
        }

        public void EnsureAdornerPanelExists()
        {
            if (adornerPanel != null) 
                return;

            adornerPanel = new AdornerPanel() {IsContentFocusable = true};
            adornerPanel.Children.Add(adornerView);
            Adorners.Add(adornerPanel);
        }
    }
}
