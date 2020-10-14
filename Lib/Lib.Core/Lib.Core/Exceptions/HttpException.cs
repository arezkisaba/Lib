using System;
using System.Net;

namespace Lib.Core
{
    public class HttpException : Exception
	{
        public HttpStatusCode StatusCode { get; set; }

        public HttpException(Exception innerException, HttpStatusCode statusCode)
            : base(null, innerException)
        {
            StatusCode = statusCode;
        }
	}
}