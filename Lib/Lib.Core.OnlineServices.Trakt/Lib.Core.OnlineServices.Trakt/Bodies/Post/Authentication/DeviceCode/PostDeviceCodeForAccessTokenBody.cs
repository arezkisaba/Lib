namespace Lib.Core.OnlineServices.Trakt
{
    public class PostDeviceCodeForAccessTokenBody
    {
		public string client_id { get; set; }
        public string client_secret { get; set; }
        public string code { get; set; }
    }
}