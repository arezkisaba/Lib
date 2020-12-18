namespace Lib.ApiServices.Kodi
{
    public partial class MovieDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SortTitle { get; set; }

        public bool IsCompleted { get; set; }

        public MovieDto(int id, string title, string sortTitle, bool isCompleted)
        {
            Id = id;
            Title = title;
            SortTitle = sortTitle;
            IsCompleted = isCompleted;
        }
    }
}
