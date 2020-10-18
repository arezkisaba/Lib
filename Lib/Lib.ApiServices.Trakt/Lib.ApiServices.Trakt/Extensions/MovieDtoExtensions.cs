namespace Lib.ApiServices.Trakt
{
    public static class MovieDtoExtensions
	{
		public static MovieDto FromQueryResponse(this MovieDto dto, GetMoviesCollectedResponse.Item response)
		{
			if (response == null)
			{
				return dto;
			}

			return new MovieDto
            {
                IdTrakt = response.movie.ids.trakt,
                Title = response.movie.title,
                Year = response.movie.year,
			};
		}

		public static MovieDto FromQueryResponse(this MovieDto dto, GetMoviesWatchedResponse.Item response)
		{
			if (response == null)
			{
				return dto;
			}

			return new MovieDto
            {
                IdTrakt = response.movie.ids.trakt,
                Title = response.movie.title,
                Year = response.movie.year,
                IsCompleted = response.plays > 0,
            };
		}
	}
}
