namespace Lib.ApiServices.Trakt
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
                Language = response.language,
                Overview = response.overview,
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
                Language = response.language,
                Overview = response.overview,
                Title = response.title
            };
        }
    }
}
