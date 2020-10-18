using System.Linq;

namespace Lib.ApiServices.Trakt
{
    public static class SeasonDtoExtensions
    {
        public static SeasonDto FromQueryResponse(this SeasonDto dto, GetSeasonsInListResponse.Item response)
        {
            if (response == null)
            {
                return dto;
            }

            var seasonDto = new SeasonDto
            {
                Number = response.season.number,
                TvShow = new TvShowDto
                {
                    Title = response.show.title
                }
            };

            return seasonDto;
        }

        public static SeasonDto FromQueryResponse(this SeasonDto dto, GetTvShowsCollectedResponse.Season response)
        {
            if (response == null)
            {
                return dto;
            }

            var seasonDto = new SeasonDto
            {
                Episodes = response.episodes.Select(obj => new EpisodeDto().FromQueryResponse(obj)).ToList(),
                Number = response.number
            };

            return seasonDto;
        }

        public static SeasonDto FromQueryResponse(this SeasonDto dto, GetTvShowsWatchedResponse.Season response)
        {
            if (response == null)
            {
                return dto;
            }

            var seasonDto = new SeasonDto
            {
                Episodes = response.episodes.Select(obj => new EpisodeDto().FromQueryResponse(obj)).ToList(),
                Number = response.number
            };

            return seasonDto;
        }
	}
}
