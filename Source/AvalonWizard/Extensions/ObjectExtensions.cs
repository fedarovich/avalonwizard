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
