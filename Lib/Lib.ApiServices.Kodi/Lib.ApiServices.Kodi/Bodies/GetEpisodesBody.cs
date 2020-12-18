namespace Lib.ApiServices.Kodi
{
    public class GetEpisodesBody
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public Params @params { get; set; }
        public string id { get; set; }

        public class Params
        {
            public int tvshowid { get; set; }
            public int season { get; set; }
            public string[] properties { get; set; }
        }
    }
}