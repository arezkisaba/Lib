using System;
using System.Linq;

namespace Lib.Core.OnlineServices.Plex
{
    public static class MovieDtoExtensions
	{
		public static MovieDto FromQueryResponse(this MovieDto dto, GetMoviesResponse.MediaContainerVideo queryResult)
		{
			if (queryResult == null)
			{
				return dto;
			}

			return new MovieDto
            {
                IsCompleted = queryResult.viewCount > 0,
                Title = Convert.ToString(queryResult.title),
                Year = queryResult.year,
                FilePaths = queryResult.Media.Part.Select(obj => obj.file).ToList(),
                IdPlex = queryResult.ratingKey
            };
		}
	}
}