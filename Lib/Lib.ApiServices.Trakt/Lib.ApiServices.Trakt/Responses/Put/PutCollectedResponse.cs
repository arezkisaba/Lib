namespace Lib.ApiServices.Trakt
{
    public class PutCollectedResponse
    {
        public Added added { get; set; }
        public Updated updated { get; set; }
        public Existing existing { get; set; }
        public Not_Found not_found { get; set; }

        public class Added
        {
            public int movies { get; set; }
            public int episodes { get; set; }
        }

        public class Updated
        {
            public int movies { get; set; }
            public int episodes { get; set; }
        }

        public class Existing
        {
            public int movies { get; set; }
            public int episodes { get; set; }
        }

        public class Not_Found
        {
            public Movie[] movies { get; set; }
            public object[] shows { get; set; }
            public object[] seasons { get; set; }
            public object[] episodes { get; set; }
            public object people { get; set; }
        }

        public class Movie
        {
            public MovieIds ids { get; set; }
        }

        public class MovieIds
        {
            public string trakt { get; set; }
            public string slug { get; set; }
            public string tvdb { get; set; }
            public string imdb { get; set; }
            public string tmdb { get; set; }
            public string tvrage { get; set; }
        }
    }
}
