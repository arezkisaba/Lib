namespace Lib.ApiServices.Tmdb
{
    public class SetInLibraryBody
    {
        public string media_type { get; set; }
        public int media_id { get; set; }
        public bool watchlist { get; set; }
    }
}
