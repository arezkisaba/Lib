namespace Lib.ApiServices.Kodi
{
    public class GetMoviesBody
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public Params @params { get; set; }
        public string id { get; set; }

        public class Params
        {
            public string[] properties { get; set; }
            public Sort sort { get; set; }
        }

        public class Sort
        {
            public string order { get; set; }
            public string method { get; set; }
            public bool ignorearticle { get; set; }
        }
    }
}