namespace Lib.ApiServices.Kodi
{
    public class GetTvShowsBody
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public Params @params { get; set; }
        public string id { get; set; }

        public class Params
        {
            public string[] properties { get; set; }
        }
    }
}