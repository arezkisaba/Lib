namespace Lib.ApiServices.Kodi
{
    public class KodiSeasonDto
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public bool IsWatched { get; set; }

        public KodiSeasonDto(int id, int number, bool isWatched)
        {
            Id = id;
            Number = number;
            IsWatched = isWatched;
        }
    }
}