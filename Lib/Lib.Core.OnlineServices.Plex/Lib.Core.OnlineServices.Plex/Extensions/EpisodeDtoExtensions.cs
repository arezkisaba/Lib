namespace Lib.Core.OnlineServices.Plex
{
    public static class EpisodeDtoExtensions
	{
		public static EpisodeDto FromQueryResponse(this EpisodeDto dto, GetEpisodesResponse.MediaContainerVideo queryResult)
		{
			if (queryResult == null)
			{
				return dto;
			}

            return new EpisodeDto
            {
                Number = queryResult.index,
                IsCompleted = queryResult.viewCount > 0,
                IdPlex = queryResult.ratingKey
            };
		}
	}
}