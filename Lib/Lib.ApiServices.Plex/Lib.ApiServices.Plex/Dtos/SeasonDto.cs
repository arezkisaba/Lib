using System.Collections.Generic;
using System.Linq;

namespace Lib.ApiServices.Plex
{
    public partial class SeasonDto
    {
        public string IdPlex { get; set; }

        public TvShowDto TvShow { get; set; }

        public int Number { get; set; }

        public bool IsCompleted
        {
            get
            {
                if (Episodes == null)
                {
                    return false;
                }

                return Episodes.All(obj => obj.IsCompleted);
            }
        }
        
        public List<EpisodeDto> Episodes { get; set; }
    }
}
