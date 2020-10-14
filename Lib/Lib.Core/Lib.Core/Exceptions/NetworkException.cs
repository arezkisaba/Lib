using System;

namespace Lib.Core
{
    public class NetworkException : Exception
    {
        public NetworkException(Exception innerException)
            : base(null, innerException)
		{
        }
    }
}