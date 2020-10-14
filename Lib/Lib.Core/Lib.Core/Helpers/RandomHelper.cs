using System;

namespace Lib.Core
{
    public static class RandomHelper
    {
        public static int Next(int min, int max)
        {
            return new Random((int)DateTime.Now.Ticks).Next(min, max + 1);
        }
    }
}