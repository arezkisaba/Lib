namespace Lib.ApiServices.Tmdb
{
    public static class SeasonDtoExtensions
    {
        public static SeasonDto FromQueryResponse(this SeasonDto dto, GetSeasonsResponse.Season response, string tvShowTitle)
        {
            if (response == null)
            {
                return dto;
            }

            var seasonDto = new SeasonDto
            {
                Id = response.id.ToString(),
                Number = response.season_number
            };

            return seasonDto;
        }
	}
}
