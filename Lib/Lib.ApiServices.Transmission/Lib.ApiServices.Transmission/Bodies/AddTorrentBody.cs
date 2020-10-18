using Newtonsoft.Json;

namespace Lib.ApiServices.Transmission
{
    public class AddTorrentBody
    {
        public string method { get; set; }
        public Arguments arguments { get; set; }

        public class Arguments
        {
            public bool paused { get; set; }

            [JsonProperty("download-dir")]
            public string downloaddir { get; set; }
            public string filename { get; set; }
        }
    }
}
