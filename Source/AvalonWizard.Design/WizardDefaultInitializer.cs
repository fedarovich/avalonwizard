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
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Model;

namespace AvalonWizard.Design
{
    public class WizardDefaultInitializer : DefaultInitializer
    {
        /// <summary>
        /// Initializes default values for the specified item using the provided editing context.
        /// </summary>
        /// <param name="item">The item to initialize. This should not be null.</param>
        /// <param name="context">The editing context. </param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="item"/> is null.</exception>
        public override void InitializeDefaults(ModelItem item, EditingContext context)
        {
            for (int i = 0; i < 3; i++)
            {
                ModelItem wizardPage = ModelFactory.CreateItem(context, Types.WizardPage.TypeId, CreateOptions.None);
                item.Content.Collection.Add(wizardPage);
            }
        }
    }
}
