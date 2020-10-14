using System.Collections.Generic;
using System.Linq;

namespace Lib.Core.OnlineServices.Trakt
{
    public partial class SeasonDto
    {
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

        public int EpisodesCollectedCount
        {
            get
            {
                var episodesCount = 0;
                foreach (var episode in Episodes)
                {
                    episodesCount++;
                }

                return episodesCount;
            }
        }
    }
}