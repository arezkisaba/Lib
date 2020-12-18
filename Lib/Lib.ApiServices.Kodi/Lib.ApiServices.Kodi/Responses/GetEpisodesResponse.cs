namespace Lib.ApiServices.Kodi
{
    public class GetEpisodesResponse
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public Result result { get; set; }

        public class Result
        {
            public Episode[] episodes { get; set; }
        }

        public class Episode
        {
            public string label { get; set; }
            public int playcount { get; set; }
            public string file { get; set; }
            public int episode { get; set; }
            public int episodeid { get; set; }
            public int season { get; set; }
        }
    }
}