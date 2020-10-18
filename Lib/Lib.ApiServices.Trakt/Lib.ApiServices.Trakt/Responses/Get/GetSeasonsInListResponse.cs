using System;

namespace Lib.ApiServices.Trakt
{
    public class GetSeasonsInListResponse
    {
        public Item[] Items { get; set; }

        public class Item
        {
            public int rank { get; set; }
            public DateTime listed_at { get; set; }
            public string type { get; set; }
            public Season season { get; set; }
            public Show show { get; set; }
        }

        public class Season
        {
            public int number { get; set; }
            public Ids ids { get; set; }
        }

        public class Ids
        {
            public string trakt { get; set; }
            public string tvdb { get; set; }
            public string tmdb { get; set; }
            public string tvrage { get; set; }
        }

        public class Show
        {
            public string title { get; set; }
            public int? year { get; set; }
            public int comment_count { get; set; }
            public Ids1 ids { get; set; }
        }

        public class Ids1
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
