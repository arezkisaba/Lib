namespace Lib.Core.OnlineServices.Trakt
{
    public partial class EpisodeDto
    {
        public SeasonDto Season { get; set; }

        public int Number { get; set; }

        public bool IsCompleted { get; set; }
    }
}