namespace Lib.ApiServices.TheMovieDatabase
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
                Number = response.season_number,
                TvShow = new TvShowDto
                {
                    Title = tvShowTitle
                }
            };

            return seasonDto;
        }
	}
}
