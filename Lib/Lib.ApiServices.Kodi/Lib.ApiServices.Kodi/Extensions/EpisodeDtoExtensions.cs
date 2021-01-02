namespace Lib.ApiServices.Kodi
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
                Id = response.episodeid.ToString(),
                Number = response.episode,
                SeasonNumber = response.season,
                IsWatched = response.playcount > 0,
                FilePath = response.file
            };
        }
    }
}
