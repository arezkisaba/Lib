namespace Lib.ApiServices.TheMovieDatabase
{
    public partial class MovieDto
    {
        public string Id { get; set; }

        public string Title { get; set; }
        
        public int? Year { get; set; }

        public string Language { get; set; }

        public bool IsWatched { get; set; }
    }
}
