using System.Collections.Generic;
using System.Linq;

namespace Lib.ApiServices.Kodi
{
    public partial class TvShowDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string FilePath { get; set; }

        public bool IsWatched
        {
            get
            {
                if (Seasons == null)
                {
                    return false;
                }

                return Seasons.All(obj => obj.IsWatched);
            }
        }

        public List<SeasonDto> Seasons { get; set; } = new List<SeasonDto>();
    }
}
