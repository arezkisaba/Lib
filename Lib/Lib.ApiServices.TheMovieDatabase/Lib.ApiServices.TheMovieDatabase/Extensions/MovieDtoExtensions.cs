namespace Lib.ApiServices.TheMovieDatabase
{
    public static class MovieDtoExtensions
	{
		public static MovieDto FromQueryResponse(this MovieDto dto, GetMoviesCollectedResponse.Result response)
		{
			if (response == null)
			{
				return dto;
			}

			int? year = null;
			if (!string.IsNullOrWhiteSpace(response.release_date))
            {
				year = int.Parse(response.release_date.Split('-')[0]);
			}

			return new MovieDto
            {
                IdTheMovieDatabase = response.id.ToString(),
                Title = response.title,
                Year = year,
				Language = response.original_language,
				IsWatched = false
			};
		}

		public static MovieDto FromQueryResponse(this MovieDto dto, GetMoviesWatchedResponse.Result response)
		{
			if (response == null)
			{
				return dto;
			}

			int? year = null;
			if (!string.IsNullOrWhiteSpace(response.release_date))
			{
				year = int.Parse(response.release_date.Split('-')[0]);
			}

			return new MovieDto
			{
				IdTheMovieDatabase = response.id.ToString(),
				Title = response.title,
				Year = year,
				Language = response.original_language,
				IsWatched = true
			};
		}
	}
}
