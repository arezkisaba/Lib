using System.Collections.Generic;
using System.Linq;

namespace Lib.Core.OnlineServices.Trakt
{
    public partial class TvShowDto
    {
        public string IdTrakt { get; set; }

        public string Title { get; set; }

        public int? Year { get; set; }

        public int EpisodesAiredCount { get; set; }

        public int EpisodesCollectedCount
        {
            get
            {
                var episodesCount = 0;
                foreach (var season in Seasons)
                {
                    foreach (var episode in season.Episodes)
                    {
                        episodesCount++;
                    }
                }

                return episodesCount;
            }
        }

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