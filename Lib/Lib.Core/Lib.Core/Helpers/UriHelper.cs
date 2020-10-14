using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Core
{
	public static class UriHelper
	{
		public static string Decode(string uri)
		{
			return Uri.UnescapeDataString(uri);
		}

		public static string Encode(string uri)
		{
			return Uri.EscapeDataString(uri);
		}

		public static Dictionary<string, string> ParseQueryString(string uri)
		{
			var query = uri.Substring(uri.IndexOf('?') + 1);
			var pairs = query.Split('&');
			return pairs
				.Select(o => o.Split('='))
				.Where(items => items.Count() == 2)
				.ToDictionary(pair => Uri.UnescapeDataString(pair[0]),
					pair => Uri.UnescapeDataString(pair[1]));
		}
	}
}