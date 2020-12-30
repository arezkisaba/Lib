using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System;
using Lib.Core;

namespace Lib.ApiServices.Transmission
{
    public class TransmissionApiService : ITransmissionApiService
    {
        private HttpService _httpService;
        private string _accessToken;
        public event EventHandler<AuthenticationResult> AuthenticationSuccessfull;

        public TransmissionApiService(string url)
        {
            _httpService = new HttpService(url, ExchangeFormat.Json);
            _httpService.AddCallbackForHttpStatusCode(HttpStatusCode.Conflict, AuthenticateAsync);
        }

        public async Task<List<GetTorrentsResponse.Torrent>> GetTorrentsAsync()
        {
            var response = await _httpService.PostAsync<GetTorrentsResponse>($"transmission/rpc", new GetTorrentsBody
            {
                method = "torrent-get",
                arguments = new GetTorrentsBody.Arguments
                {
                    fields = new string[] { "id", "name", "percentDone", "hashString", "startDate" }
                }
            });

            return response.arguments.torrents.ToList();
        }

        public async Task<AddTorrentResponse> AddTorrentAsync(string torrentUrl, string downloadDirectory)
        {
            var response = await _httpService.PostAsync<AddTorrentResponse>($"transmission/rpc", new AddTorrentBody
            {
                method = "torrent-add",
                arguments = new AddTorrentBody.Arguments
                {
                    filename = torrentUrl,
                    downloaddir = downloadDirectory
                }
            });

            if (response.result != "success" || response.arguments == null)
            {
                throw new TorrentAddException($"request result : {response.result}");
            }

            return response;
        }

        public async Task<RemoveTorrentResponse> RemoveTorrentAsync(int id)
        {
            var response = await _httpService.PostAsync<RemoveTorrentResponse>($"transmission/rpc", new RemoveTorrentBody
            {
                method = "torrent-remove",
                arguments = new RemoveTorrentBody.Arguments
                {
                    ids = new int[] { id }
                }
            });

            if (response.result != "success")
            {
                throw new TorrentRemoveException($"request result : {response.result}");
            }

            return response;
        }

        private async Task AuthenticateAsync()
        {
            var response = await _httpService.PostAsync("transmission/rpc", null);

            IEnumerable<string> headers;
            if (response.Headers.TryGetValues("X-Transmission-Session-Id", out headers))
            {
                _accessToken = headers.First();
                _httpService.AddHeader("X-Transmission-Session-Id", _accessToken);

                AuthenticationSuccessfull?.Invoke(this, new AuthenticationResult
                {
                    AccessToken = _accessToken,
                });
            }
        }
    }

    public class AuthenticationResult
    {
        public string AccessToken { get; set; }
    }
}
