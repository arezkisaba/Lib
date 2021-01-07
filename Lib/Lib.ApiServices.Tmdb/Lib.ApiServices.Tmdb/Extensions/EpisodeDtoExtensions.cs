namespace Lib.ApiServices.Tmdb
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
                Id = response.id.ToString(),
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
                Id = response.id.ToString(),
                Number = response.episode_number,
                IsWatched = true
            };
        }
    }
}
