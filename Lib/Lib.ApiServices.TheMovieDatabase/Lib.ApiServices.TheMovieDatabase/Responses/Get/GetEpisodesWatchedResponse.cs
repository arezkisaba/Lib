namespace Lib.ApiServices.TheMovieDatabase
{
    public class GetEpisodesWatchedResponse
    {
        public int page { get; set; }
        public Result[] results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }

        public class Result
        {
            public string air_date { get; set; }
            public int episode_number { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string overview { get; set; }
            public string production_code { get; set; }
            public int season_number { get; set; }
            public int show_id { get; set; }
            public string still_path { get; set; }
            public float vote_average { get; set; }
            public int vote_count { get; set; }
            public float rating { get; set; }
        }

    }
}
