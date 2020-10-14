using System;

namespace Lib.Core.OnlineServices.Trakt
{
    public class GetTvShowsWatchedResponse
    {
        public Item[] Items { get; set; }

        public class Item
        {
            public int plays { get; set; }
            public DateTime? last_watched_at { get; set; }
            public Show show { get; set; }
            public Season[] seasons { get; set; }
        }

        public class Show
        {
            public string title { get; set; }
            public int? year { get; set; }
            public Ids ids { get; set; }
            public string overview { get; set; }
            public Airs airs { get; set; }
            public int runtime { get; set; }
            public string certification { get; set; }
            public string network { get; set; }
            public string country { get; set; }
            public string trailer { get; set; }
            public string homepage { get; set; }
            public string status { get; set; }
            public float rating { get; set; }
            public int votes { get; set; }
            public DateTime updated_at { get; set; }
            public string language { get; set; }
            public string[] available_translations { get; set; }
            public string[] genres { get; set; }
            public int aired_episodes { get; set; }
            public int comment_count { get; set; }
        }

        public class Ids
        {
            public string trakt { get; set; }
            public string slug { get; set; }
            public string tvdb { get; set; }
            public string imdb { get; set; }
            public string tmdb { get; set; }
            public string tvrage { get; set; }
        }

        public class Airs
        {
            public string day { get; set; }
            public string time { get; set; }
            public string timezone { get; set; }
        }

        public class Season
        {
            public int number { get; set; }
            public Episode[] episodes { get; set; }
        }

        public class Episode
        {
            public int number { get; set; }
            public int plays { get; set; }
            public DateTime? last_watched_at { get; set; }
        }
    }
}