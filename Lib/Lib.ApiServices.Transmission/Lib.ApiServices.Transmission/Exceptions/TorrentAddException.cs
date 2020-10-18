using System;

namespace Lib.ApiServices.Transmission
{
    public class TorrentAddException : Exception
    {
        public TorrentAddException(string message)
            : base(message)
        {
        }
    }
}
