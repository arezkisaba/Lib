namespace Lib.ApiServices.Trakt
{
    public partial class EpisodeDto
    {
        public SeasonDto Season { get; set; }

        public int Number { get; set; }

        public bool IsWatched { get; set; }
    }
}
