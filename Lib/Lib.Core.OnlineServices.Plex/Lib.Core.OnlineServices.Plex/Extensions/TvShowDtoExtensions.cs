namespace Lib.Core.OnlineServices.Plex
{
    public static class TvShowDtoExtensions
    {
		public static TvShowDto FromQueryResponse(this TvShowDto dto, GetTvShowsResponse.MediaContainerDirectory queryResult)
		{
			if (queryResult == null)
			{
				return dto;
			}

            return new TvShowDto
            {
                Title = queryResult.title,
                Year = queryResult.year,
                IdPlex = queryResult.ratingKey
            };
		}
	}
}