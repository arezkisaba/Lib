using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Lib.ApiServices.Plex
{
    public interface IPlexService
    {
        event EventHandler<AuthenticationResult> AuthenticationSuccessfull;

        void SetPlexProperties(string plexClientIdentifier, string plexDeviceName, string plexProduct, string plexVersion);

        Task<List<GetSectionsResponse.MediaContainerDirectory>> GetSectionsAsync();
        
        Task<List<MovieDto>> GetMoviesAsync(string libraryId);
        
        Task PutMovieLockedAsync(string libraryId, string mediaId, string mediaTitle);
        
        Task PutMovieWatchedAsync(string mediaId);
        
        Task<List<TvShowDto>> GetTvShowsAsync(string LibraryId);
        
        Task PutTvShowLockedAsync(string libraryId, string mediaId, string mediaTitle);
        
        Task<List<SeasonDto>> GetSeasonsAsync(string tvShowId);
        
        Task<List<EpisodeDto>> GetEpisodesAsync(string seasonId);
        
        Task PutEpisodeWatchedAsync(string mediaId);
        
        Task RefreshSectionsAsync();
    }
}
