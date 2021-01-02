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
				Id = response.movie.ids.trakt,
				IdTmdb = response.movie.ids.tmdb,
				Title = response.movie.title,
                Year = response.movie.year,
				Language = response.movie.language,
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
                Id = response.movie.ids.trakt,
				IdTmdb = response.movie.ids.tmdb,
				Title = response.movie.title,
				Year = response.movie.year,
				Language = response.movie.language,
				IsWatched = response.plays > 0,
            };
		}
	}
}
