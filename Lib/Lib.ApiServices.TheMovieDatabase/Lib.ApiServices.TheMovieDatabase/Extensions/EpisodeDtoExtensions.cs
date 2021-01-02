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
                Number = response.episode_number
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
