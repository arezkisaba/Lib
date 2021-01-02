namespace Lib.ApiServices.TheMovieDatabase
{
    public class GetAccountResponse
    {
        public Avatar avatar { get; set; }
        public int id { get; set; }
        public string iso_639_1 { get; set; }
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
        public bool include_adult { get; set; }
        public string username { get; set; }

        public class Avatar
        {
            public Gravatar gravatar { get; set; }
        }

        public class Gravatar
        {
            public string hash { get; set; }
        }
    }
}
