namespace Lib.ApiServices.Torrents
{
    public class TorrentDto
    {
        public string DescriptionUrl { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public long Seeds { get; set; }
        public double Size { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Url.Substring(0, 30)} - {Size} Bytes - SD : {Seeds} - {Provider}";
        }
    }
}
