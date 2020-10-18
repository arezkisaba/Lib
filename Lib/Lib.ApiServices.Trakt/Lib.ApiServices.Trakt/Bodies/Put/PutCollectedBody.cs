using System;

namespace Lib.ApiServices.Trakt
{
    public class PutCollectedBody
    {
        public Movie[] movies { get; set; }
        public Show[] shows { get; set; }
        public Episode[] episodes { get; set; }

        public class Movie
        {
            public DateTime collected_at { get; set; }
            public string title { get; set; }
            public int? year { get; set; }
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

        public class Show
        {
            public string title { get; set; }
            public int? year { get; set; }
            public ShowIds ids { get; set; }
            public Season[] seasons { get; set; }
        }

        public class ShowIds
        {
            public string trakt { get; set; }
            public string slug { get; set; }
            public string tvdb { get; set; }
            public string imdb { get; set; }
            public string tmdb { get; set; }
            public string tvrage { get; set; }
        }

        public class Season
        {
            public int number { get; set; }
            public EpisodeInSeason[] episodes { get; set; }
        }

        public class EpisodeInSeason
        {
            public int number { get; set; }
        }

        public class Episode
        {
            public EpisodeIds ids { get; set; }
        }

        public class EpisodeIds
        {
            public string trakt { get; set; }
            public string tvdb { get; set; }
            public string imdb { get; set; }
            public string tmdb { get; set; }
            public string tvrage { get; set; }
        }
    }
}
