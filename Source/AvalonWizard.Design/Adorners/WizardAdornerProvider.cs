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
