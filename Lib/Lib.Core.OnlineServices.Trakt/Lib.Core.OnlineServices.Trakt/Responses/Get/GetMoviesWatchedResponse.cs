using System;

namespace Lib.Core.OnlineServices.Trakt
{
    public class GetMoviesWatchedResponse
    {
        public Item[] Items { get; set; }

        public class Item
        {
            public int plays { get; set; }
            public DateTime? last_watched_at { get; set; }
            public Movie movie { get; set; }
        }

        public class Movie
        {
            public string title { get; set; }
            public int? year { get; set; }
            public Ids ids { get; set; }
            public string tagline { get; set; }
            public string overview { get; set; }
            public string released { get; set; }
            public string trailer { get; set; }
            public string homepage { get; set; }
            public float rating { get; set; }
            public int votes { get; set; }
            public DateTime updated_at { get; set; }
            public string language { get; set; }
            public string[] available_translations { get; set; }
            public string[] genres { get; set; }
            public string certification { get; set; }
            public string country { get; set; }
            public int comment_count { get; set; }
            public int? runtime { get; set; }
        }

        public class Ids
        {
            public string trakt { get; set; }
            public string slug { get; set; }
            public string imdb { get; set; }
            public string tmdb { get; set; }
            public string tvdb { get; set; }
            public string tvrage { get; set; }
        }
    }
}