using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.ApiServices.TheMovieDatabase
{
    public interface ITheMovieDatabaseApiService
    {
        event EventHandler<AuthenticationResult> AuthenticationSuccessfull;

        event EventHandler<AuthenticationInformations> AuthenticationInformationsAvailable;

        Task<List<MovieDto>> SearchMovieAsync(string query);

        Task<List<MovieDto>> GetMoviesInLibraryAsync();

        Task<MovieDto> GetMovieAsync(string movieId);

        Task<SetMovieWatchedResponse> SetMovieWatchedAsync(string movieId, bool isWatched);

        Task<List<TvShowDto>> SearchTvShowAsync(string query);

        Task<List<TvShowDto>> GetTvShowsInLibraryAsync();
        
        Task<TvShowDto> GetTvShowAsync(string tvShowId);

        Task<SetEpisodeWatchedResponse> SetEpisodeWatchedAsync(string tvShowId, int seasonNumber, int episodeNumber, bool isWatched);

        Task<List<TranslationDto>> GetMovieTranslationsAsync(string movieId, string language = null);

        Task<List<TranslationDto>> GetTvShowTranslationsAsync(string tvShowId, string language = null);

        Task<SetInLibraryResponse> SetInLibraryAsync(string mediaId, string mediaType);
    }
}
