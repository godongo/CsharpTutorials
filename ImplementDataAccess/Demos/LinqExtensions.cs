using System;
using System.Collections.Generic;

namespace ImplementDataAccess.Demos
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> MyWhere<TSource>(
        this IEnumerable<TSource> source,
        Func<TSource, bool> predicate)
        {
            foreach (TSource item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
