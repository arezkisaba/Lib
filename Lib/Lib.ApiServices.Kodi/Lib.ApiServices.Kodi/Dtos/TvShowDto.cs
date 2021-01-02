using System.Collections.Generic;

namespace Lib.ApiServices.Kodi
{
    public partial class TvShowDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string SortTitle { get; set; }

        public bool IsWatched { get; set; }

        public string FilePath { get; set; }

        public List<SeasonDto> Seasons { get; set; } = new List<SeasonDto>();

        public TvShowDto(int id, string title, string sortTitle, bool isWatched, string filePath)
        {
            Id = id;
            Title = title;
            SortTitle = sortTitle;
            IsWatched = isWatched;
            FilePath = filePath;
        }
    }
}
