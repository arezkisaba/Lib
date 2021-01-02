namespace Lib.ApiServices.TheMovieDatabase
{
    public static class TvShowDtoExtensions
    {
        public static TvShowDto FromQueryResponse(this TvShowDto dto, GetTvShowsInLibraryResponse.Result response)
		{
			if (response == null)
			{
				return dto;
			}

            int? year = null;
            if (!string.IsNullOrWhiteSpace(response.first_air_date))
            {
                year = int.Parse(response.first_air_date.Split('-')[0]);
            }

            return new TvShowDto
            {
                Id = response.id.ToString(),
                Title = response.name,
                Year = year,
                Language = response.original_language,
                Seasons = null,
            };
		}
	}
}
