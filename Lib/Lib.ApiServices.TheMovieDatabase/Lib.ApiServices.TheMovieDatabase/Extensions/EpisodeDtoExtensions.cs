namespace Lib.ApiServices.TheMovieDatabase
{
    public static class EpisodeDtoExtensions
    {
        public static EpisodeDto FromQueryResponse(this EpisodeDto dto, GetEpisodesResponse.Episode response)
        {
            if (response == null)
            {
                return dto;
            }

            return new EpisodeDto
            {
                Number = response.episode_number,
                IsWatched = false
            };
        }

        public static EpisodeDto FromQueryResponse(this EpisodeDto dto, GetEpisodesWatchedResponse.Result response)
        {
            if (response == null)
            {
                return dto;
            }

            return new EpisodeDto
            {
                Number = response.episode_number,
                IsWatched = true,
                Season = new SeasonDto
                {
                    Number = response.season_number,
                    TvShow = new TvShowDto
                    {
                        IdTheMovieDatabase = response.show_id.ToString(),
                    }
                }
            };
        }
    }
}
