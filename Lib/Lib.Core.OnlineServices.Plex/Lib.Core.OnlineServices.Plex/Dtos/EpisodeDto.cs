namespace Lib.Core.OnlineServices.Plex
{
    public partial class EpisodeDto
    {
        public string IdPlex { get; set; }

        public SeasonDto Season { get; set; }

        public int Number { get; set; }

        public bool IsCompleted { get; set; }
    }
}