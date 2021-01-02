using System.Collections.Generic;
using System.Linq;

namespace Lib.ApiServices.Kodi
{
    public class SeasonDto
    {
        public string Id { get; set; }

        public int Number { get; set; }

        public bool IsWatched
        {
            get
            {
                if (Episodes == null)
                {
                    return false;
                }

                return Episodes.All(obj => obj.IsWatched);
            }
        }

        public List<EpisodeDto> Episodes { get; set; } = new List<EpisodeDto>();
    }
}