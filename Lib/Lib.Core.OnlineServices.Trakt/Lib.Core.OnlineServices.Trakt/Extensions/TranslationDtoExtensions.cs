namespace Lib.Core.OnlineServices.Trakt
{
    public static class TranslationDtoExtensions
    {
		public static TranslationDto FromQueryResponse(this TranslationDto dto, GetMovieTranslationsResponse.Item response)
		{
			if (response == null)
			{
				return dto;
			}

			return new TranslationDto
            {
                Overview = response.overview,
                Tagline = response.tagline,
                Title = response.title
			};
		}

        public static TranslationDto FromQueryResponse(this TranslationDto dto, GetTvShowTranslationsResponse.Item response)
        {
            if (response == null)
            {
                return dto;
            }

            return new TranslationDto
            {
                Overview = response.overview,
                Tagline = response.tagline,
                Title = response.title
            };
        }
    }
}