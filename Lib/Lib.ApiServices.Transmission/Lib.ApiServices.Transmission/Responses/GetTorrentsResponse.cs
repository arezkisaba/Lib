namespace Lib.ApiServices.Transmission
{
    public class GetTorrentsResponse
    {
        public Arguments arguments { get; set; }
        public string result { get; set; }

        public class Arguments
        {
            public Torrent[] torrents { get; set; }
        }

        public class Torrent
        {
            public int id { get; set; }
            public string name { get; set; }
            public string provider { get; set; }
            public double percentDone { get; set; }
            public string hashString { get; set; }
            public int startDate { get; set; }
        }
    }
}
