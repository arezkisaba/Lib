namespace Lib.ApiServices.Kodi
{
    public class GetMoviesResponse
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public Result result { get; set; }

        public class Result
        {
            public Movie[] movies { get; set; }
        }

        public class Movie
        {
            public int movieid { get; set; }
            public string label { get; set; }
            public int playcount { get; set; }
            public string sorttitle { get; set; }
            public string file { get; set; }
        }
    }
}