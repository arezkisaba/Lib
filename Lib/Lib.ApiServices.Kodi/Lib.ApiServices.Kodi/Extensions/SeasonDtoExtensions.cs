namespace Lib.ApiServices.Kodi
{
    public static class SeasonDtoExtensions
    {
        public static SeasonDto FromQueryResponse(this SeasonDto dto, GetSeasonsResponse.Season response)
        {
            if (response == null)
            {
                return dto;
            }

            var seasonDto = new SeasonDto
            {
                Id = response.seasonid.ToString(),
                Number = response.season
            };

            return seasonDto;
        }
	}
}
