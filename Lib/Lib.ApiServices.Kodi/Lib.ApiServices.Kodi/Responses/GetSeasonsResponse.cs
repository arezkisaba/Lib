namespace Lib.ApiServices.Kodi
{
    public class GetSeasonsResponse
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public Result result { get; set; }

        public class Result
        {
            public Season[] seasons { get; set; }
        }

        public class Season
        {
            public int playcount { get; set; }
            public string file { get; set; }
            public int season { get; set; }
            public int seasonid { get; set; }
        }
    }
}