using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.ApiServices.TheMovieDatabase
{
    public interface ITheMovieDatabaseApiService
    {
        event EventHandler<AuthenticationResult> AuthenticationSuccessfull;

        event EventHandler<AuthenticationInformations> AuthenticationInformationsAvailable;

        Task<List<MovieDto>> GetMoviesInLibraryAsync();

        Task<SetMovieWatchedResponse> SetMovieWatchedAsync(string movieId, bool isWatched);

        Task<List<TvShowDto>> GetTvShowsInLibraryAsync();

        Task<SetEpisodeWatchedResponse> SetEpisodeWatchedAsync(string tvShowId, int seasonNumber, int episodeNumber, bool isWatched);

        Task<List<TranslationDto>> GetMovieTranslationsAsync(string movieId, string language = null);

        Task<List<TranslationDto>> GetTvShowTranslationsAsync(string id, string language = null);
    }
}
