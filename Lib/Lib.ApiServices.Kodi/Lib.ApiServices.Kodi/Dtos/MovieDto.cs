namespace Lib.ApiServices.Kodi
{
    public partial class MovieDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public bool IsWatched { get; set; }

        public string FilePath { get; set; }
    }
}
