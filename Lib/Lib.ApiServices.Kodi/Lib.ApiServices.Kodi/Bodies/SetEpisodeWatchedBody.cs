namespace Lib.ApiServices.Kodi
{
    public class SetEpisodeWatchedBody
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public Params @params { get; set; }
        public string id { get; set; }

        public class Params
        {
            public int episodeid { get; set; }
            public int? playcount { get; set; }
        }
    }
}