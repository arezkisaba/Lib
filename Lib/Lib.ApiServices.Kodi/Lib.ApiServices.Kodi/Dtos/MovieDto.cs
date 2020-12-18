namespace Lib.ApiServices.Kodi
{
    public partial class MovieDto
    {
        public string Title { get; set; }

        public string SortTitle { get; set; }

        public bool IsCompleted { get; set; }

        public MovieDto(string title, string sortTitle, bool isCompleted)
        {
            Title = title;
            SortTitle = sortTitle;
            IsCompleted = isCompleted;
        }
    }
}
