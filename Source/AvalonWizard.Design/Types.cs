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
using Microsoft.Windows.Design.Metadata;

namespace AvalonWizard.Design
{
    internal class Types
    {
        public class Wizard
        {
            public static readonly TypeIdentifier TypeId = new TypeIdentifier(
                "http://schemas.pavel.fedarovich.com/winfx/2010/xaml/presentation",
                "Wizard");

            public static readonly PropertyIdentifier CurrentPageIndexProperty =
                new PropertyIdentifier(TypeId, "CurrentPageIndex");
        }

        public class WizardPage
        {
            public static readonly TypeIdentifier TypeId = new TypeIdentifier(
                "http://schemas.pavel.fedarovich.com/winfx/2010/xaml/presentation",
                "WizardPage");
        }

        public static class Designer
        {
            public static readonly TypeIdentifier TypeId = new TypeIdentifier(
                "http://schemas.pavel.fedarovich.com/winfx/2010/xaml/presentation",
                "Designer");

            public static readonly PropertyIdentifier PageIndexProperty =
                new PropertyIdentifier(TypeId, "PageIndex");
        }
    }
}
