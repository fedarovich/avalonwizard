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
