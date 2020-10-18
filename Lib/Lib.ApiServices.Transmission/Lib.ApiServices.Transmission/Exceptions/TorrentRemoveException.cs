using System;

namespace Lib.ApiServices.Transmission
{
    public class TorrentRemoveException : Exception
    {
        public TorrentRemoveException(string message)
            : base(message)
        {
        }
    }
}
