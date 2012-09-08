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

using AvalonWizard.Aero;
using AvalonWizard.Design.Adorners;
using AvalonWizard.Design.Menu;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Features;
using Microsoft.Windows.Design.Metadata;

namespace AvalonWizard.Design
{
    internal class Metadata : IProvideAttributeTable
    {
        #region Implementation of IProvideAttributeTable

        public AttributeTable AttributeTable
        {
            get
            {
                var builder = new AttributeTableBuilder();

                builder.AddCustomAttributes(
                    typeof(Wizard),
                    new FeatureAttribute(typeof(WizardContextMenuProvider)));
                builder.AddCustomAttributes(
                    typeof(Wizard),
                    new FeatureAttribute(typeof(WizardAdornerProvider)));
                builder.AddCustomAttributes(
                    typeof(Wizard),
                    new FeatureAttribute(typeof(WizardDefaultInitializer)));
                builder.AddCustomAttributes(
                    typeof (Wizard),
                    new ToolboxBrowsableAttribute(true));
                builder.AddCustomAttributes(
                    typeof (WizardPage),
                    new ToolboxBrowsableAttribute(true));
                builder.AddCustomAttributes(
                    typeof(AeroWizardHeader),
                    new ToolboxBrowsableAttribute(false));
                builder.AddCustomAttributes(
                    typeof(AeroWizardPageChrome),
                    new ToolboxBrowsableAttribute(false));
                builder.AddCustomAttributes(
                    typeof (WizardAdornerView),
                    new ToolboxBrowsableAttribute(false));

                return builder.CreateTable();
            }
        }

        #endregion
    }
}
