using System;

namespace Lib.Core
{
    public static class NugetDebugTestHelper
    {
        public static void ThrowException(string parameter1, string parameter2)
        {
            System.Diagnostics.Debug.WriteLine($"Attention ça va péter : {parameter1}, {parameter2} !");
            throw new NotImplementedException();
        }
    }
}