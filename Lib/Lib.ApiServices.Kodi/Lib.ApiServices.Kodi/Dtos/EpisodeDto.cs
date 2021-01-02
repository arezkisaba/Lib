namespace Lib.ApiServices.Kodi
{
    public class EpisodeDto
    {
        public string Id { get; set; }

        public int Number { get; set; }

        public int SeasonNumber { get; set; }

        public bool IsWatched { get; set; }

        public string FilePath { get; set; }
    }
}