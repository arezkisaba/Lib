using System.Collections.Generic;
using System.Linq;

namespace Lib.Core.OnlineServices.Plex
{
    public partial class TvShowDto
    {
        public string IdPlex { get; set; }

        public string Title { get; set; }

        public int? Year { get; set; }

        public bool IsCompleted
        {
            get
            {
                if (Seasons == null)
                {
                    return false;
                }

                return Seasons.All(obj => obj.IsCompleted);
            }
        }

        public List<SeasonDto> Seasons { get; set; }
    }
}