namespace Lib.ApiServices.Trakt
{
    public static class EpisodeDtoExtensions
    {
        public static EpisodeDto FromQueryResponse(this EpisodeDto dto, GetTvShowsCollectedResponse.Episode response)
        {
            if (response == null)
            {
                return dto;
            }

            return new EpisodeDto
            {
                Number = response.number
            };
        }

        public static EpisodeDto FromQueryResponse(this EpisodeDto dto, GetTvShowsWatchedResponse.Episode response)
        {
            if (response == null)
            {
                return dto;
            }

            return new EpisodeDto
            {
                Number = response.number,
                IsCompleted = response.plays > 0
            };
        }
	}
}
