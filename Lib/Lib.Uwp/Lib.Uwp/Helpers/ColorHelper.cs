using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Windows.UI;

namespace Lib.Uwp
{
	public static class ColorHelper
	{
		public static Color FromHex(string hex)
		{
			byte alpha;
			byte pos = 0;
			hex = hex.Replace("#", "");
			if (hex.Length == 8)
			{
				alpha = Convert.ToByte(hex.Substring(pos, 2), 16);
				pos = 2;
			}
			else
			{
				alpha = Convert.ToByte("FF", 16);
			}
			var red = Convert.ToByte(hex.Substring(pos, 2), 16);
			pos += 2;
			var green = Convert.ToByte(hex.Substring(pos, 2), 16);
			pos += 2;
			var blue = Convert.ToByte(hex.Substring(pos, 2), 16);
			var color = Color.FromArgb(alpha, red, green, blue);
			return color;
		}

		public static Dictionary<string, Color> ReadAll()
		{
			var colors = typeof(Colors).GetRuntimeProperties().Select(c => new { Color = (Color)c.GetValue(null), c.Name });
			return colors.ToDictionary(x => x.Name, x => x.Color);
		}
	}
}