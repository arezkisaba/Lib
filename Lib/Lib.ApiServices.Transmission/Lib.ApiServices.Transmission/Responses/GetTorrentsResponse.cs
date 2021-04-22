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
            public string hashString { get; set; }
            public int startDate { get; set; }
            public string name { get; set; }
            public double downloadedEver { get; set; }
            public double leftUntilDone { get; set; }
            public int peersConnected { get; set; }
            public int peersGettingFromUs { get; set; }
            public int peersSendingToUs { get; set; }
            public double percentDone { get; set; }
            public double rateDownload { get; set; }
            public double rateUpload { get; set; }
            public double sizeWhenDone { get; set; }
            public string provider { get; set; }
        }
    }
}
