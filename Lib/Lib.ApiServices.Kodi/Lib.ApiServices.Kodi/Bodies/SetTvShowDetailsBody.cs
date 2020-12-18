namespace Lib.ApiServices.Kodi
{
    public class SetTvShowDetailsBody
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public Params @params { get; set; }
        public string id { get; set; }

        public class Params
        {
            public int tvshowid { get; set; }
            public string sorttitle { get; set; }
        }
    }
}