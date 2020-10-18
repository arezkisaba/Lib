namespace Lib.ApiServices.Trakt
{
    public class GetMovieTranslationsResponse
    {
        public Item[] Items { get; set; }

        public class Item
        {
            public string title { get; set; }
            public string overview { get; set; }
            public string tagline { get; set; }
            public string language { get; set; }
        }
    }
}
