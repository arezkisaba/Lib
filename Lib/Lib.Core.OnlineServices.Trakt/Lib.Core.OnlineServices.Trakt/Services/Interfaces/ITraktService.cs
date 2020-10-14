using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Lib.Core.OnlineServices.Trakt
{
    public interface ITraktService
    {
        event EventHandler<AuthenticationResult> AuthenticationSuccessfull;

        event EventHandler<AuthenticationInformations> AuthenticationInformationsAvailable;

        Task<AccountDto> GetAccountAsync();

        Task<PostClientIdForDeviceCodeResponse> PostClientIdForDeviceCodeAsync(string clientId);
        
        Task<PostDeviceCodeForAccessTokenResponse> PostDeviceCodeForAccessTokenAsync(string code, string clientId, string clientSecret);
        
        Task<PostRefreshTokenForAccessTokenResponse> PostRefreshTokenForAccessTokenAsync(string refreshToken);

        Task<List<MovieDto>> GetMoviesCollectedAsync();

        Task<List<MovieDto>> GetMoviesWatchedAsync();

        Task<List<TranslationDto>> GetMovieTranslationsAsync(MovieDto movie, string language);

        Task<PutWatchedResponse> PutMovieWatchedAsync(MovieDto movie);

        Task<List<TvShowDto>> GetTvShowsCollectedAsync();

        Task<List<TvShowDto>> GetTvShowsWatchedAsync();

        Task<List<TranslationDto>> GetTvShowTranslationsAsync(TvShowDto tvShow, string language);

        Task<PutCollectedResponse> PutTvShowCollectedAsync(TvShowDto tvShow);

        Task<PutWatchedResponse> PutTvShowWatchedAsync(TvShowDto tvShow);

        Task<List<SeasonDto>> GetSeasonsInListAsync(string listName);

        Task<PutWatchedResponse> PutSeasonWatchedAsync(SeasonDto season);

        Task<PutWatchedResponse> PutEpisodeWatchedAsync(EpisodeDto episode);
    }
}
