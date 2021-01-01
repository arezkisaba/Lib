namespace Lib.ApiServices.Trakt
{
    public partial class MovieDto
    {
        public string IdTrakt { get; set; }

        public string Title { get; set; }
        
        public int? Year { get; set; }

        public string Language { get; set; }

        public bool IsCompleted { get; set; }
    }
}
