using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Core
{
    public static class IListExtensions
	{
		public static void Move<T>(this IList<T> list, int oldIndex, int newIndex)
		{
			T aux = list[newIndex];
			list[newIndex] = list[oldIndex];
			list[oldIndex] = aux;
		}

        public static int RemoveAll<T>(this IList<T> collection, Func<T, bool> match)
        {
            var items = collection.Where(match).ToList();

            foreach (var item in items)
            {
                collection.Remove(item);
            }

            return items.Count;
        }

        public static List<TSource> ToListByCopy<TSource>(this IList<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return new List<TSource>(source);
        }
    }
}