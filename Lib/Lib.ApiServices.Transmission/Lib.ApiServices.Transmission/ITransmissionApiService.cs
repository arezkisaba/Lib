using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Lib.ApiServices.Transmission
{
    public interface ITransmissionApiService
    {
        event EventHandler<AuthenticationResult> AuthenticationSuccessfull;

        Task<List<GetTorrentsResponse.Torrent>> GetTorrentsAsync();

        Task<AddTorrentResponse> AddTorrentAsync(string torrentUrl, string downloadDirectory);

        Task<RemoveTorrentResponse> DeleteTorrentAsync(int id);
    }
}
