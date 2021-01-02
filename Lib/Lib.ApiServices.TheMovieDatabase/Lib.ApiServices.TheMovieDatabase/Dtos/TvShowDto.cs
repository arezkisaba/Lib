using System.Collections.Generic;
using System.Linq;

namespace Lib.ApiServices.TheMovieDatabase
{
    public partial class TvShowDto
    {
        public string IdTheMovieDatabase { get; set; }

        public string Title { get; set; }

        public int? Year { get; set; }

        public string Language { get; set; }

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

        public List<SeasonDto> Seasons { get; set; }
    }
}
