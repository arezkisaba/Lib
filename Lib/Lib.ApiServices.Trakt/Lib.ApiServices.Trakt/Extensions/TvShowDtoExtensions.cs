using System.Linq;

namespace Lib.ApiServices.Trakt
{
    public static class TvShowDtoExtensions
    {
        public static TvShowDto FromQueryResponse(this TvShowDto dto, GetTvShowsCollectedResponse.Item response)
		{
			if (response == null)
			{
				return dto;
			}

			return new TvShowDto
            {
                Id = response.show.ids.trakt,
                IdTmdb = response.show.ids.tmdb,
                Title = response.show.title,
                Year = response.show.year,
                Language = response.show.language,
                EpisodesAiredCount = response.show.aired_episodes,
                Seasons = response.seasons.Select(obj => new SeasonDto().FromQueryResponse(obj)).ToList(),
            };
		}

		public static TvShowDto FromQueryResponse(this TvShowDto dto, GetTvShowsWatchedResponse.Item response)
		{
			if (response == null)
			{
				return dto;
			}

            return new TvShowDto
            {
                Id = response.show.ids.trakt,
                IdTmdb = response.show.ids.tmdb,
                Title = response.show.title,
                Year = response.show.year,
                Language = response.show.language,
                Seasons = response.seasons.Select(obj => new SeasonDto().FromQueryResponse(obj)).ToList(),
            };
        }
	}
}
