namespace Lib.ApiServices.Tmdb
{
    public class GetRequestTokenResponse
    {
        public bool success { get; set; }
        public string expires_at { get; set; }
        public string request_token { get; set; }
    }
}
