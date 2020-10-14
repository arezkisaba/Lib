using System;

namespace Lib.Core.OnlineServices.Transmission
{
    public class TorrentRemoveException : Exception
    {
        public TorrentRemoveException(string message)
            : base(message)
        {
        }
    }
}
