using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AvalonWizard.Extensions
{
    internal static class EnumerableExtensions
    {
        internal static IEnumerable<Tuple<T1, T2>> Zip<T1, T2>(IEnumerable<T1> first, IEnumerable<T2> second)
        {
            var firstEnum = first.GetEnumerator();
            var secondEnum = second.GetEnumerator();
            try
            {
                while (firstEnum.MoveNext() && secondEnum.MoveNext())
                {
                    yield return new Tuple<T1, T2>(firstEnum.Current, secondEnum.Current);
                }
            }
            finally
            {
                secondEnum.Dispose();
                firstEnum.Dispose();
            }
        }

        internal static IEnumerable<T3> Zip<T1, T2, T3>(IEnumerable<T1> first, IEnumerable<T2> second, Func<T1, T2, T3> func)
        {
            var firstEnum = first.GetEnumerator();
            var secondEnum = second.GetEnumerator();
            try
            {
                while (firstEnum.MoveNext() && secondEnum.MoveNext())
                {
                    yield return func(firstEnum.Current, secondEnum.Current);
                }
            }
            finally
            {
                secondEnum.Dispose();
                firstEnum.Dispose();
            }
        }

        internal class Tuple<T1, T2>
        {
            public Tuple(T1 item1, T2 item2)
            {
                Item1 = item1;
                Item2 = item2;
            }

            public T1 Item1
            {
                get;
                private set;
            }

            public T2 Item2
            {
                get;
                private set;
            }
        }
    }
}
