namespace Lib.ApiServices.Kodi
{
    public partial class MovieDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SortTitle { get; set; }

        public bool IsWatched { get; set; }

        public string FilePath { get; set; }

        public MovieDto(int id, string title, string sortTitle, bool isWatched, string filePath)
        {
            Id = id;
            Title = title;
            SortTitle = sortTitle;
            IsWatched = isWatched;
            FilePath = filePath;
        }
    }
}
