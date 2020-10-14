using System.Linq;

namespace Lib.Core.OnlineServices.Trakt
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
                IdTrakt = response.show.ids.trakt,
                Title = response.show.title,
                Year = response.show.year,
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
                IdTrakt = response.show.ids.trakt,
                Title = response.show.title,
                Year = response.show.year,
                Seasons = response.seasons.Select(obj => new SeasonDto().FromQueryResponse(obj)).ToList(),
            };
        }
	}
}