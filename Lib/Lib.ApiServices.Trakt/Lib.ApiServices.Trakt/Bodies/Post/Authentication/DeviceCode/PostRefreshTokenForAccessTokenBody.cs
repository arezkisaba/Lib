namespace Lib.ApiServices.Trakt
{
    public class PostRefreshTokenForAccessTokenBody
    {
        public string refresh_token { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string redirect_uri { get; set; }
        public string grant_type { get; set; }
    }
}
