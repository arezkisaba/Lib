namespace Lib.ApiServices.TheMovieDatabase
{
    public static class TranslationDtoExtensions
    {
		public static TranslationDto FromQueryResponse(this TranslationDto dto, GetMovieTranslationsResponse.Translation response)
		{
			if (response == null)
			{
				return dto;
			}

			return new TranslationDto
            {
                Language = response.iso_639_1,
                Overview = response.data.overview,
                Title = response.data.title
			};
		}

        public static TranslationDto FromQueryResponse(this TranslationDto dto, GetTvShowTranslationsResponse.Translation response)
        {
            if (response == null)
            {
                return dto;
            }

            return new TranslationDto
            {
                Language = response.iso_639_1,
                Overview = response.data.overview,
                Title = response.data.name
            };
        }
    }
}
