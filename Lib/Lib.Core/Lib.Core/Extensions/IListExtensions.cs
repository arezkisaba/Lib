using System.Collections.Generic;

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
    }
}