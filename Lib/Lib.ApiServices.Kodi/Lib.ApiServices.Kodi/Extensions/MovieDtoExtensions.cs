namespace Lib.ApiServices.Kodi
{
    public static class MovieDtoExtensions
	{
		public static MovieDto FromQueryResponse(this MovieDto dto, GetMoviesInLibraryResponse.Movie response)
		{
			if (response
				== null)
			{
				return dto;
			}

			return new MovieDto
			{
				Id = response.movieid.ToString(),
				Title = response.label,
				IsWatched = response.playcount > 0,
				FilePath = response.file
			};
		}
	}
}
