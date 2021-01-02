namespace Lib.ApiServices.TheMovieDatabase
{
    public static class MovieDtoExtensions
	{
		public static MovieDto FromQueryResponse(this MovieDto dto, GetMoviesInLibraryResponse.Result response)
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
                Id = response.id.ToString(),
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
				Id = response.id.ToString(),
				Title = response.title,
				Year = year,
				Language = response.original_language,
				IsWatched = true
			};
		}

		public static MovieDto FromQueryResponse(this MovieDto dto, SearchMovieResponse.Result response)
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
				Id = response.id.ToString(),
				Title = response.title,
				Year = year,
				Language = response.original_language,
				IsWatched = false
			};
		}

		public static MovieDto FromQueryResponse(this MovieDto dto, GetMovieResponse response)
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
				Id = response.id.ToString(),
				Title = response.title,
				Year = year,
				Language = response.original_language,
				IsWatched = false
			};
		}

	}
}
