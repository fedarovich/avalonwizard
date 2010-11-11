﻿#region Licence
// This file is part of AvalonWizard.
// 
// AvalonWizard is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 2.1 of the License, or
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AvalonWizard.Aero
{
    /// <summary>
    /// Provides borders and background color for <see cref="WizardPage"/> when Aero Wizard style is set.
    /// </summary>
    public class AeroWizardPageChrome : ContentControl
    {
        static AeroWizardPageChrome()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AeroWizardPageChrome), new FrameworkPropertyMetadata(typeof(AeroWizardPageChrome)));
        }
    }
}
