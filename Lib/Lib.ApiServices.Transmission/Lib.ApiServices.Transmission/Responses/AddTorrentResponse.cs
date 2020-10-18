using Newtonsoft.Json;

namespace Lib.ApiServices.Transmission
{
    public class AddTorrentResponse
    {
        public Arguments arguments { get; set; }
        public string result { get; set; }

        public class Arguments
        {
            [JsonProperty("torrent-added")]
            public TorrentAdded torrentadded { get; set; }
        }

        public class TorrentAdded
        {
            public string hashString { get; set; }
            public int id { get; set; }
            public string name { get; set; }
        }
    }
}
