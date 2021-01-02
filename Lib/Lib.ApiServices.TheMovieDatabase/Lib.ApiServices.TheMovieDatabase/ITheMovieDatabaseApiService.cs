using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.ApiServices.TheMovieDatabase
{
    public interface ITheMovieDatabaseApiService
    {
        event EventHandler<AuthenticationResult> AuthenticationSuccessfull;

        event EventHandler<AuthenticationInformations> AuthenticationInformationsAvailable;

        Task<GetRequestTokenResponse> GetRequestTokenAsync();

        Task<PostRequestTokenForSessionIdResponse> PostRequestTokenForSessionIdAsync(PostRequestTokenForSessionIdBody body);

        Task<AccountDto> GetAccountAsync();

        Task<List<MovieDto>> GetMoviesCollectedAsync();

        Task<List<MovieDto>> GetMoviesWatchedAsync();

        Task<List<TranslationDto>> GetMovieTranslationsAsync(MovieDto movie, string language = null);

        Task<PostWatchedResponse> PostMovieWatchedAsync(MovieDto movie);

        Task<List<TvShowDto>> GetTvShowsCollectedAsync();

        Task<List<EpisodeDto>> GetEpisodesWatchedAsync();
        
        Task<List<TranslationDto>> GetTvShowTranslationsAsync(TvShowDto tvShow, string language = null);

        Task<PostWatchedResponse> PostEpisodeWatchedAsync(TvShowDto tvShow, SeasonDto season, EpisodeDto episode);

        Task<List<SeasonDto>> GetSeasonsAsync(TvShowDto tvShow);

        Task<List<EpisodeDto>> GetEpisodesAsync(TvShowDto tvShow, SeasonDto season);
    }
}
