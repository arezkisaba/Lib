namespace Lib.ApiServices.Kodi
{
    public class KodiEpisodeDto
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int SeasonNumber { get; set; }

        public bool IsWatched { get; set; }

        public string FilePath { get; set; }

        public KodiEpisodeDto(int id, int number, int seasonNumber, bool isWatched, string filePath)
        {
            Id = id;
            Number = number;
            SeasonNumber = seasonNumber;
            IsWatched = isWatched;
            FilePath = filePath;
        }
    }
}