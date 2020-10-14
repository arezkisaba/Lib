using System;

namespace Lib.Core.OnlineServices.Rawg
{
    public class GetGameResponse
    {
        public int id { get; set; }
        public string slug { get; set; }
        public string name { get; set; }
        public string name_original { get; set; }
        public string description { get; set; }
        public int metacritic { get; set; }
        public Metacritic_Platforms[] metacritic_platforms { get; set; }
        public string released { get; set; }
        public bool tba { get; set; }
        public DateTime updated { get; set; }
        public string background_image { get; set; }
        public string background_image_additional { get; set; }
        public string website { get; set; }
        public float rating { get; set; }
        public int rating_top { get; set; }
        public Rating[] ratings { get; set; }
        public Reactions reactions { get; set; }
        public int added { get; set; }
        public Added_By_Status added_by_status { get; set; }
        public int playtime { get; set; }
        public int screenshots_count { get; set; }
        public int movies_count { get; set; }
        public int creators_count { get; set; }
        public int achievements_count { get; set; }
        public int parent_achievements_count { get; set; }
        public string reddit_url { get; set; }
        public string reddit_name { get; set; }
        public string reddit_description { get; set; }
        public string reddit_logo { get; set; }
        public int reddit_count { get; set; }
        public int twitch_count { get; set; }
        public int youtube_count { get; set; }
        public int reviews_text_count { get; set; }
        public int ratings_count { get; set; }
        public int suggestions_count { get; set; }
        public string[] alternative_names { get; set; }
        public string metacritic_url { get; set; }
        public int parents_count { get; set; }
        public int additions_count { get; set; }
        public int game_series_count { get; set; }
        public object user_game { get; set; }
        public int reviews_count { get; set; }
        public string saturated_color { get; set; }
        public string dominant_color { get; set; }
        public Parent_Platforms[] parent_platforms { get; set; }
        public Platform2[] platforms { get; set; }
        public Store[] stores { get; set; }
        public Developer[] developers { get; set; }
        public Genre[] genres { get; set; }
        public Tag[] tags { get; set; }
        public Publisher[] publishers { get; set; }
        public Esrb_Rating esrb_rating { get; set; }
        public object clip { get; set; }
        public string description_raw { get; set; }

        public class Reactions
        {
        }

        public class Added_By_Status
        {
            public int yet { get; set; }
            public int owned { get; set; }
            public int beaten { get; set; }
            public int toplay { get; set; }
            public int dropped { get; set; }
            public int playing { get; set; }
        }

        public class Esrb_Rating
        {
            public int id { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
        }

        public class Metacritic_Platforms
        {
            public int metascore { get; set; }
            public string url { get; set; }
            public Platform platform { get; set; }
        }

        public class Platform
        {
            public int platform { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
        }

        public class Rating
        {
            public int id { get; set; }
            public string title { get; set; }
            public int count { get; set; }
            public float percent { get; set; }
        }

        public class Parent_Platforms
        {
            public Platform1 platform { get; set; }
        }

        public class Platform1
        {
            public int id { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
        }

        public class Platform2
        {
            public Platform3 platform { get; set; }
            public string released_at { get; set; }
            public object requirements { get; set; }
        }

        public class Platform3
        {
            public int id { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
            public object image { get; set; }
            public object year_end { get; set; }
            public object year_start { get; set; }
            public int games_count { get; set; }
            public string image_background { get; set; }
        }

        public class Store
        {
            public int id { get; set; }
            public string url { get; set; }
            public Store1 store { get; set; }
        }

        public class Store1
        {
            public int id { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
            public string domain { get; set; }
            public int games_count { get; set; }
            public string image_background { get; set; }
        }

        public class Developer
        {
            public int id { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
            public int games_count { get; set; }
            public string image_background { get; set; }
        }

        public class Genre
        {
            public int id { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
            public int games_count { get; set; }
            public string image_background { get; set; }
        }

        public class Tag
        {
            public int id { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
            public string language { get; set; }
            public int games_count { get; set; }
            public string image_background { get; set; }
        }

        public class Publisher
        {
            public int id { get; set; }
            public string name { get; set; }
            public string slug { get; set; }
            public int games_count { get; set; }
            public string image_background { get; set; }
        }
    }
}
