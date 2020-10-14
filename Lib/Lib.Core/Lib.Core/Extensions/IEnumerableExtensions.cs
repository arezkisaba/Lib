using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Core
{
	public static class IEnumerableExtensions
	{
		private static readonly Random Random = new Random();

		public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
		{
			using (var enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					var current = enumerator.Current;
					action.Invoke(current);
				}
			}
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
		{
			var list2 = list.ToList();
			var list3 = new List<T>(list2.Count);

			while (list2.Count > 0)
			{
				var index = Random.Next(list2.Count);
				list3.Add(list2[index]);
				list2.RemoveAt(index);
			}

			return list3;
		}
	}
}