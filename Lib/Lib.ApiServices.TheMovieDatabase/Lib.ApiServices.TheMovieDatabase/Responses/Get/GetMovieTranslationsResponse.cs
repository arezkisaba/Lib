namespace Lib.ApiServices.TheMovieDatabase
{
    public class GetMovieTranslationsResponse
    {
        public int id { get; set; }
        public Translation[] translations { get; set; }

        public class Translation
        {
            public string iso_3166_1 { get; set; }
            public string iso_639_1 { get; set; }
            public string name { get; set; }
            public string english_name { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public string title { get; set; }
            public string overview { get; set; }
            public string homepage { get; set; }
        }

    }
}
