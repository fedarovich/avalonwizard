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

namespace AvalonWizard.Mvvm
{
    /// <summary>
    /// Arguments for <see cref="IWizardController.NavigationRequested"/> event.
    /// </summary>
    public class WizardNavigationEventArgs : EventArgs
    {
        private readonly object target;
        private readonly WizardNavigationDirection direction;

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardNavigationEventArgs" /> class.
        /// </summary>
        /// <param name="direction">The direction.</param>
        public WizardNavigationEventArgs(WizardNavigationDirection direction)
        {
            this.direction = direction;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardNavigationEventArgs" /> class.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <remarks>The <see cref="Direction"/> will be set <see cref="WizardNavigationDirection.Forward"/>.</remarks>
        public WizardNavigationEventArgs(Object target)
        {
            this.target = target;
        }

        /// <summary>
        /// Gets the target.
        /// The value can be one of the following:
        /// <list type="table">
        ///     <listheader>
        ///         <term>Type</term>
        ///         <description>Interpretation</description>
        ///     </listheader>
        ///     <item>
        ///         <term><see cref="Int32"/></term>
        ///         <description>The page index.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="String"/></term>
        ///         <description>The page name.</description>
        ///     </item>
        ///     <item>
        ///         <term><see cref="WizardPage"/></term>
        ///         <description>The page.</description>
        ///     </item>
        ///     <item>
        ///         <term>Any other object.</term>
        ///         <description>The page having the paratemer as its view model.</description>
        ///     </item>
        ///     <item>
        ///         <term><c>null</c></term>
        ///         <description>The next page.</description>
        ///     </item>
        /// </list>
        /// </summary>
        public object Target
        {
            get { return target; }
        }

        /// <summary>
        /// Gets the navigation direction.
        /// </summary>
        /// <value>The direction.</value>
        public WizardNavigationDirection Direction
        {
            get { return direction; }
        }
    }
}
