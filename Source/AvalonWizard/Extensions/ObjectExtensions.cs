#region Licence
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

namespace AvalonWizard.Extensions
{
    /// <summary>
    /// Extensions for all objects.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Checks whether the object is equal to one of the specified values.
        /// </summary>
        public static bool In<T>(this T value, params T[] values)
        {
            return values.Contains(value);
        }
    }
}
