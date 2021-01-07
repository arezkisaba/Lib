using System;

namespace Lib.Core
{
    public static class RandomHelper
    {
        public static int GetInt(int min, int max)
        {
            return new Random((int)DateTime.Now.Ticks).Next(min, max + 1);
        }

		public static string GetRandomString(int count)
		{
			var buf = string.Empty;
			var rand = new Random((int)DateTime.Now.Ticks);

			for (var i = 0; i < count; i++)
			{
				var j = rand.Next(48, 122);
				buf += (char)j;
			}

			return buf;
		}

		public static string GetRandomAlphaLowerCaseString(int count)
		{
			var buf = string.Empty;
			var rand = new Random((int)DateTime.Now.Ticks);
			for (var i = 0; i < count; i++)
			{
				var j = rand.Next(97, 122);
				buf += (char)j;
			}
			return buf;
		}

		public static string GetRandomAlphaUpperCaseString(int count)
		{
			var buf = string.Empty;
			var rand = new Random((int)DateTime.Now.Ticks);
			for (var i = 0; i < count; i++)
			{
				var j = rand.Next(65, 90);
				buf += (char)j;
			}
			return buf;
		}
	}
}