namespace Lib.ApiServices.TheMovieDatabase
{
    public class PostRequestTokenForSessionIdResponse
    {
        public bool success { get; set; }
        public string session_id { get; set; }
    }
}