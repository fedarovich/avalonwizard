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
