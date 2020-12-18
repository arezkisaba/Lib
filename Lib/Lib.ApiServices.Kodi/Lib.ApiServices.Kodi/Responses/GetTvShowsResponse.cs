namespace Lib.ApiServices.Kodi
{
    public class GetTvShowsResponse
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public Result result { get; set; }

        public class Result
        {
            public TvShow[] tvshows { get; set; }
        }

        public class TvShow
        {
            public int tvshowid { get; set; }
            public string label { get; set; }
            public int playcount { get; set; }
            public string sorttitle { get; set; }
            public string file { get; set; }
        }
    }
}