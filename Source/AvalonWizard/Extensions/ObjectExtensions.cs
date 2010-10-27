using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvalonWizard.Extensions
{
    public static class ObjectExtensions
    {
        public static bool In<T>(this T value, params T[] values)
        {
            return values.Contains(value);
        }
    }
}
