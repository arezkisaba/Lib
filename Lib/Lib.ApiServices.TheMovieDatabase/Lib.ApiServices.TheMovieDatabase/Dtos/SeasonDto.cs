using System.Collections.Generic;
using System.Linq;

namespace Lib.ApiServices.TheMovieDatabase
{
    public partial class SeasonDto
    {
        public TvShowDto TvShow { get; set; }

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
