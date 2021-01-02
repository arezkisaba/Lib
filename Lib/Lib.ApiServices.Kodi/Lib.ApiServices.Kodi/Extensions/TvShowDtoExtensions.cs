using System.Linq;

namespace Lib.ApiServices.Kodi
{
    public static class TvShowDtoExtensions
    {
        public static TvShowDto FromQueryResponse(this TvShowDto dto, GetTvShowsResponse.TvShow response)
		{
			if (response == null)
			{
				return dto;
			}

			return new TvShowDto
			{
				Id = response.tvshowid.ToString(),
				Title = response.label,
				FilePath = response.file
			};
		}
	}
}
