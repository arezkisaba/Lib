using Lib.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.ApiServices.Kodi
{
    public class KodiApiService : IKodiApiService
    {
        private HttpService _httpService;

        public KodiApiService(string url)
        {
            _httpService = new HttpService(url, ExchangeFormat.Json);
        }

        public async Task<List<GetMoviesResponse.Movie>> GetMoviesAsync()
        {
            var body = new GetMoviesBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.GetMovies",
                @params = new GetMoviesBody.Params
                {
                    properties = new string[]
                    {
                        "sorttitle",
                        "playcount",
                        "file"
                    },
                    sort = new GetMoviesBody.Sort
                    {
                        order = "ascending",
                        method = "label",
                        ignorearticle = true
                    }
                },
                id = "VideoLibrary.GetMovies"
            };


            var responseObject = await _httpService.PostAsync<GetMoviesResponse>($"", body);
            return responseObject.result.movies.OrderBy(obj => obj.label).ToList();
        }

        public async Task<SetMovieDetailsResponse> SetMoviesDetailsAsync(int movieId, string sortTitle, int playCount)
        {
            var body = new SetMovieDetailsBody
            {
                jsonrpc = "2.0",
                method = "VideoLibrary.SetMovieDetails",
                @params = new SetMovieDetailsBody.Params
                {
                    movieid = movieId,
                    sorttitle = sortTitle,
                    playcount = playCount,
                },
                id = "VideoLibrary.SetMovieDetails"
            };


            return await _httpService.PostAsync<SetMovieDetailsResponse>($"", body);
        }
    }
}
