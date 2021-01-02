using System.Collections.Generic;

namespace Lib.ApiServices.Kodi
{
    public class SeasonDto
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public bool IsWatched { get; set; }

        public List<EpisodeDto> Episodes { get; set; } = new List<EpisodeDto>();

        public SeasonDto(int id, int number, bool isWatched)
        {
            Id = id;
            Number = number;
            IsWatched = isWatched;
        }
    }
}