using System;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace Lib.Core
{
    public class HttpService
    {
        private HttpClient _httpClient;
        private ExchangeFormat? _exchangeFormat;
        private bool _randomizeUserAgent;
        private int _timeout;
        private int _tryCount;
        private JsonSerializerSettings _jsonSerializerSettings;
        private List<Tuple<HttpStatusCode, Func<Task>>> _funcs;
        private string _additionnalQueryParameters;

        public HttpService(
            string baseUrl,
            ExchangeFormat? exchangeFormat = null,
            IDictionary<string, string> headers = null,
            bool randomizeUserAgent = false,
            int timeout = 10000,
            int tryCount = 3)
        {
            _exchangeFormat = exchangeFormat;
            _randomizeUserAgent = randomizeUserAgent;
            _timeout = timeout;
            _tryCount = tryCount;

            _httpClient = new HttpClient(new CustomHttpClientHandler() { }, disposeHandler: false);
            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.Timeout = TimeSpan.FromMilliseconds(_timeout);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    AddHeader(header.Key, header.Value);
                }
            }

            if (exchangeFormat != null)
            {
                AddHeader("Accept", GetMediaType());
            }

            if (_randomizeUserAgent)
            {
                AddHeader("User-Agent", GenerateRandomizedUserAgent());
            }

            _jsonSerializerSettings = default;
            _funcs = new List<Tuple<HttpStatusCode, Func<Task>>>();
        }

        public void SetJsonSerializerSettings(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        public void AddCallbackForHttpStatusCode(HttpStatusCode httpStatusCode, Func<Task> func)
        {
            _funcs.Add(Tuple.Create(httpStatusCode, func));
        }

        public void AddHeader(string key, string value)
        {
            if (_httpClient.DefaultRequestHeaders.Contains(key))
            {
                _httpClient.DefaultRequestHeaders.Remove(key);
            }

            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation(key, value);
        }

        public void AddQueryParameters(string additionnalQueryParameters)
        {
            _additionnalQueryParameters = additionnalQueryParameters;
        }

        #region Verbs

        public async Task<byte[]> GetByteArrayAsync(string url, bool disableCallbackAndRetry = false)
        {
            var response = await SendAsync(url, HttpMethod.Get, null, disableCallbackAndRetry);
            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<string> GetStringAsync(string url, bool disableCallbackAndRetry = false)
        {
            var response = await SendAsync(url, HttpMethod.Get, null, disableCallbackAndRetry);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<HttpResponseMessage> GetAsync(string url, bool disableCallbackAndRetry = false)
        {
            return await SendAsync(url, HttpMethod.Get, null, disableCallbackAndRetry, ensureSuccessStatusCode: false);
        }

        public async Task<T> GetAsync<T>(string url, bool disableCallbackAndRetry = false)
        {
            var responseMessage = await SendAsync(url, HttpMethod.Get, null, disableCallbackAndRetry);
            var response = await responseMessage.Content.ReadAsStringAsync();
            var responseObject = await DeserializeByExchangeFormatAsync<T>(response);
            return responseObject;
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url, bool disableCallbackAndRetry = false)
        {
            return await SendAsync(url, HttpMethod.Delete, null, disableCallbackAndRetry, ensureSuccessStatusCode: false);
        }

        public async Task<T> DeleteAsync<T>(string url, bool disableCallbackAndRetry = false)
        {
            var responseMessage = await SendAsync(url, HttpMethod.Delete, null, disableCallbackAndRetry);
            var response = await responseMessage.Content.ReadAsStringAsync();
            var responseObject = await DeserializeByExchangeFormatAsync<T>(response);
            return responseObject;
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object contentObject, bool disableCallbackAndRetry = false)
        {
            HttpContent httpContent = null;
            if (contentObject != null)
            {
                var content = await SerializeByExchangeFormatAsync(contentObject);
                httpContent = new StringContent(content, Encoding.UTF8, GetMediaType());
            }

            var responseMessage = await SendAsync(url, HttpMethod.Post, httpContent, disableCallbackAndRetry, ensureSuccessStatusCode: false);
            httpContent?.Dispose();
            return responseMessage;
        }

        public async Task<T> PostAsync<T>(string url, object contentObject, bool disableCallbackAndRetry = false)
        {
            HttpContent httpContent = null;
            if (contentObject != null)
            {
                var content = await SerializeByExchangeFormatAsync(contentObject);
                httpContent = new StringContent(content, Encoding.UTF8, GetMediaType());
            }

            var responseMessage = await SendAsync(url, HttpMethod.Post, httpContent, disableCallbackAndRetry: disableCallbackAndRetry);
            var response = await responseMessage.Content.ReadAsStringAsync();
            var responseObject = await DeserializeByExchangeFormatAsync<T>(response);

            httpContent?.Dispose();
            return responseObject;
        }

        public async Task<HttpResponseMessage> PostAsFormDataAsync(string url, string content, bool disableCallbackAndRetry = false)
        {
            using (var httpContent = new StringContent(content, Encoding.UTF8, "multipart/form-data"))
            {
                return await SendAsync(url, HttpMethod.Post, httpContent, disableCallbackAndRetry, ensureSuccessStatusCode: false);
            }
        }

        public async Task<HttpResponseMessage> PostAsFormUrlEncodedAsync(string url, IEnumerable<KeyValuePair<string, string>> content, bool disableCallbackAndRetry = false)
        {
            using (var httpContent = new FormUrlEncodedContent(content))
            {
                return await SendAsync(url, HttpMethod.Post, httpContent, disableCallbackAndRetry, ensureSuccessStatusCode: false);
            }
        }

        public async Task<T> PostAsFormUrlEncodedAsync<T>(string url, IEnumerable<KeyValuePair<string, string>> contentObject, bool disableCallbackAndRetry = false)
        {
            HttpContent httpContent = null;
            if (contentObject != null)
            {
                httpContent = new FormUrlEncodedContent(contentObject);
            }

            var responseMessage = await SendAsync(url, HttpMethod.Post, httpContent, disableCallbackAndRetry);
            var response = await responseMessage.Content.ReadAsStringAsync();
            var responseObject = await DeserializeByExchangeFormatAsync<T>(response);

            httpContent?.Dispose();
            return responseObject;
        }

        public async Task<HttpResponseMessage> PutAsync(string url, object contentObject, bool disableCallbackAndRetry = false)
        {
            HttpContent httpContent = null;
            if (contentObject != null)
            {
                var content = await SerializeByExchangeFormatAsync(contentObject);
                httpContent = new StringContent(content, Encoding.UTF8, GetMediaType());
            }

            var responseMessage = await SendAsync(url, HttpMethod.Put, httpContent, disableCallbackAndRetry, ensureSuccessStatusCode: false);
            httpContent?.Dispose();
            return responseMessage;
        }

        public async Task<T> PutAsync<T>(string url, object contentObject, bool disableCallbackAndRetry = false)
        {
            HttpContent httpContent = null;
            if (contentObject != null)
            {
                var content = await SerializeByExchangeFormatAsync(contentObject);
                httpContent = new StringContent(content, Encoding.UTF8, GetMediaType());
            }

            var responseMessage = await SendAsync(url, HttpMethod.Put, httpContent, disableCallbackAndRetry);
            var response = await responseMessage.Content.ReadAsStringAsync();
            var responseObject = await DeserializeByExchangeFormatAsync<T>(response);

            httpContent?.Dispose();
            return responseObject;
        }

        #endregion

        #region Internal use

        private async Task<HttpResponseMessage> SendAsync(string url, HttpMethod method, HttpContent content, bool disableCallbackAndRetry, int tryCount = 0, Exception lastException = null, bool ensureSuccessStatusCode = true)
        {
            if (tryCount >= _tryCount)
            {
                if (lastException == null)
                {
                    throw new InvalidOperationException($"Invalid lastException");
                }

                throw lastException;
            }

            tryCount++;

            HttpResponseMessage responseMessage = null;

            try
            {
                url += _additionnalQueryParameters;

                var httpRequestMessage = new HttpRequestMessage(method, url) { Content = content };
                var tmpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
                responseMessage = tmpResponseMessage;
                
                if (ensureSuccessStatusCode)
                {
                    tmpResponseMessage.EnsureSuccessStatusCode();
                }

                return responseMessage;
            }
            catch (Exception ex)
            {
                var httpException = new HttpException(ex, responseMessage.StatusCode);

                if (disableCallbackAndRetry)
                {
                    throw httpException;
                }

                if (responseMessage == null)
                {
                    var networkException = new NetworkException(ex);
                    return await SendAsync(url, method, content, disableCallbackAndRetry, tryCount, networkException);
                }

                var response = await responseMessage.Content.ReadAsStringAsync();
                foreach (var func in _funcs)
                {
                    if (func.Item1 == responseMessage.StatusCode)
                    {
                        await func.Item2();
                    }
                }

                return await SendAsync(url, method, content, disableCallbackAndRetry, tryCount, httpException);
            }
        }
        
        private string GetMediaType()
        {
            string result;
            if (_exchangeFormat == ExchangeFormat.Json)
            {
                result = "application/json";
            }
            else if (_exchangeFormat == ExchangeFormat.Xml)
            {
                result = "application/xml";
            }
            else
            {
                throw new InvalidOperationException($"exchangeFormat ({_exchangeFormat}) not found");
            }

            return result;
        }

        private string GenerateRandomizedUserAgent()
        {
            var userAgents = new List<string>
            {
                "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36",
                "Mozilla/5.0 (Windows NT 6.3; rv:36.0) Gecko/20100101 Firefox/36.0",
                "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; AS; rv:11.0) like Gecko",
                "Opera/9.80 (X11; Linux i686; Ubuntu/14.10) Presto/2.12.388 Version/12.16",
                "Mozilla/5.0 (X11; Linux x86_64; rv:17.0) Gecko/20121202 Firefox/17.0 Iceweasel/17.0.1",
                "Mozilla/5.0 (X11; Linux) KHTML/4.9.1 (like Gecko) Konqueror/4.9",
                "Lynx/2.8.8dev.3 libwww-FM/2.14 SSL-MM/1.4.1"
            };

            var rand = new Random();
            var position = rand.Next(0, userAgents.Count - 1);
            return userAgents.ElementAt(position);
        }

        private async Task<T> DeserializeByExchangeFormatAsync<T>(string content)
        {
            T result = default;
            if (_exchangeFormat == ExchangeFormat.Json)
            {
                result = await Serializer.JsonDeserializeAsync<T>(content, _jsonSerializerSettings);
            }
            else if (_exchangeFormat == ExchangeFormat.Xml)
            {
                result = await Serializer.XmlDeserializeAsync<T>(content);
            }
            else
            {
                throw new InvalidOperationException($"exchangeFormat ({_exchangeFormat}) not found");
            }

            return result;
        }

        private async Task<string> SerializeByExchangeFormatAsync(object obj)
        {
            var result = string.Empty;
            if (_exchangeFormat == ExchangeFormat.Json)
            {
                result = await Serializer.JsonSerializeAsync(obj, _jsonSerializerSettings);
            }
            else if (_exchangeFormat == ExchangeFormat.Xml)
            {
                result = await Serializer.XmlSerializeAsync(obj);
            }
            else
            {
                throw new InvalidOperationException($"exchangeFormat ({_exchangeFormat}) not found");
            }

            return result;
        }

        #endregion
    }

    public class CustomHttpClientHandler : HttpClientHandler
    {
        public CustomHttpClientHandler()
            : base()
        {
            AllowAutoRedirect = true;
            UseCookies = true;
            CookieContainer = new CookieContainer();
            ClientCertificateOptions = ClientCertificateOption.Automatic;
            PreAuthenticate = true;

            if (SupportsAutomaticDecompression)
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            }
        }
    }
}
