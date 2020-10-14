using System;

namespace Lib.Core.OnlineServices.Transmission
{
    public class TorrentAddException : Exception
    {
        public TorrentAddException(string message)
            : base(message)
        {
        }
    }
}
