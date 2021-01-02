namespace Lib.ApiServices.Trakt
{
    public partial class MovieDto
    {
        public string Id { get; set; }
        
        public string IdTmdb { get; set; }

        public string Title { get; set; }
        
        public int? Year { get; set; }

        public string Language { get; set; }

        public bool IsWatched { get; set; }
    }
}
