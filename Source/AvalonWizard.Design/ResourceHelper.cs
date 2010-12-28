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
using System.Reflection;
using System.Text;

namespace AvalonWizard.Design
{
    internal static class ResourceHelper
    {
        internal static Uri GetImageUri(String imageName)
        {
            String path = String.Format("{0};component/Images/{1}",
                                        Assembly.GetExecutingAssembly().GetName().Name,
                                        imageName);
            return new Uri(path, UriKind.Relative);
        }

        internal static Uri GetEffectUri(String effectName)
        {
            String path = String.Format("{0};component/Effects/{1}",
                                        Assembly.GetExecutingAssembly().GetName().Name,
                                        effectName);
            return new Uri(path, UriKind.Relative);
        }
    }
}
