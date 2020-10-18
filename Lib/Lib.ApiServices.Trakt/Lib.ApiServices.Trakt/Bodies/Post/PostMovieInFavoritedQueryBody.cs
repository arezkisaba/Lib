namespace Lib.ApiServices.Trakt
{
	public class PostMovieInFavoritedQueryBody
	{
		public bool favorite { get; set; }
		public int media_id { get; set; }
		public string media_type { get; set; }
	}
}
