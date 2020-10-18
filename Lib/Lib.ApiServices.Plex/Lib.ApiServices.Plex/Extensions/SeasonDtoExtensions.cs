namespace Lib.ApiServices.Plex
{
    public static class SeasonDtoExtensions
	{
		public static SeasonDto FromQueryResponse(this SeasonDto dto, GetSeasonsResponse.MediaContainerDirectory queryResult)
		{
			if (queryResult == null)
			{
				return dto;
			}

			var seasonDto = new SeasonDto
            {
                Episodes = null,
				Number = queryResult.index,
                IdPlex = queryResult.ratingKey
            };

			return seasonDto;
		}
	}
}
