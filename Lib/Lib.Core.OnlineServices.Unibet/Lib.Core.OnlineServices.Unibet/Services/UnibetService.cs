using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Lib.Core.OnlineServices.Unibet
{
    public class UnibetService : IUnibetService
    {
        private HttpService _httpService;

        public UnibetService(
            string cookie)
        {
            var headers = new Dictionary<string, string>();
            headers.Add("Accept", "*/*");
            headers.Add("Accept-Encoding", "gzip, deflate, br");
            headers.Add("Accept-Language", "en-US,en;q=0.9");
            headers.Add("Connection", "keep-alive");
            headers.Add("Cookie", cookie);
            headers.Add("Host", "www.unibet.fr");
            headers.Add("Origin", "https://www.unibet.fr");
            headers.Add("Referer", "https://www.unibet.fr");
            headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.181 Safari/537.36");
            headers.Add("X-Requested-With", "XMLHttpRequest");

            _httpService = new HttpService("https://www.unibet.fr/zones/betslip/", ExchangeFormat.Json, headers);
        }

        public async Task ClearBetsAsync()
        {
            await _httpService.PostAsync($"clear.json", null);
        }

        public async Task<List<GetBetsResponse.Betleg>> GetBetsAsync()
        {
            var objectResponse = await _httpService.PostAsync<GetBetsResponse>($"simple.json", null);
            return objectResponse.betlegs.ToList();
        }

        public async Task<AddBetResponse> AddBetAsync(AddBetBody body)
        {
            var dictionary = new List<KeyValuePair<string, string>>()
            {
                { new KeyValuePair<string, string>(nameof(body.selectionId), body.selectionId) },
                { new KeyValuePair<string, string>(nameof(body.priceUp), body.priceUp) },
                { new KeyValuePair<string, string>(nameof(body.priceDown), body.priceDown) },
                { new KeyValuePair<string, string>(nameof(body.priceType), body.priceType) },
            };

            var objectResponse = await _httpService.PostAsFormUrlEncodedAsync<AddBetResponse>($"add.json", dictionary);
            return objectResponse;
        }

        public async Task<PlaceSimpleBetsResponse> PlaceSimpleBetsAsync(PlaceSimpleBetsBody body)
        {
            var bettype = "S";
            var dictionary = new List<KeyValuePair<string, string>>()
            {
                { new KeyValuePair<string, string>(nameof(body.isfreebet), body.isfreebet ? "true" : "false") },
                { new KeyValuePair<string, string>(nameof(bettype), bettype) },
            };

            foreach (var stake in body.stakes)
            {
                dictionary.Add(new KeyValuePair<string, string>($"{nameof(body.stakes)}[]", stake.ToString()));
            }

            foreach (var selection in body.selections)
            {
                dictionary.Add(new KeyValuePair<string, string>($"{nameof(body.selections)}[]", selection));
            }

            var objectResponse = await _httpService.PostAsFormUrlEncodedAsync<PlaceSimpleBetsResponse>($"placesingles.json", dictionary);
            return objectResponse;
        }

        public async Task<PlaceMultipleBetsResponse> PlaceMultipleBetsAsync(PlaceMultipleBetsBody body)
        {
            string bettype = "A";

            if (body.selections.Count() == 1)
            {
                throw new Exception("selections must have at least two elements");
            }
            else if (body.selections.Count() == 2)
            {
                bettype = "D";
            }
            else if (body.selections.Count() == 3)
            {
                bettype = "T";
            }
            else
            {
                bettype = "A";
            }

            var dictionary = new List<KeyValuePair<string, string>>()
            {
                { new KeyValuePair<string, string>(nameof(body.stake), body.stake.ToString()) },
                { new KeyValuePair<string, string>(nameof(body.isfreebet), body.isfreebet ? "true" : "false") },
                { new KeyValuePair<string, string>(nameof(bettype), bettype) },
            };

            foreach (var selection in body.selections)
            {
                dictionary.Add(new KeyValuePair<string, string>($"{nameof(body.selections)}[]", selection));
            }

            var objectResponse = await _httpService.PostAsFormUrlEncodedAsync<PlaceMultipleBetsResponse>($"placemultiple.json", dictionary);
            return objectResponse;
        }

        public async Task CancelPlaceBetsAsync(CancelPlaceBetsBody body)
        {
            var dictionary = new List<KeyValuePair<string, string>>()
            {
                { new KeyValuePair<string, string>(nameof(body.betslipid), body.betslipid) },
            };

            await _httpService.PostAsFormUrlEncodedAsync($"cancel.json", dictionary);
        }

        public async Task<ConfirmBetsResponse> ConfirmBetsAsync(ConfirmBetsBody body)
        {
            var dictionary = new List<KeyValuePair<string, string>>()
            {
                { new KeyValuePair<string, string>(nameof(body.betslipId), body.betslipId) },
                { new KeyValuePair<string, string>(nameof(body.betslipkey), body.betslipkey) },
                { new KeyValuePair<string, string>(nameof(body.clearAfterConfirm), body.clearAfterConfirm ? "true" : "false") },
            };

            var objectResponse = await _httpService.PostAsFormUrlEncodedAsync<ConfirmBetsResponse>($"confirm.json", dictionary);
            return objectResponse;
        }
    }
}
