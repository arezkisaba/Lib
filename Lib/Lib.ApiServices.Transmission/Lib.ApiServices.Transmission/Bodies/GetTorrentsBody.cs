namespace Lib.ApiServices.Transmission
{
    public class GetTorrentsBody
    {
        public string method { get; set; }
        public Arguments arguments { get; set; }

        public class Arguments
        {
            public string[] fields { get; set; }
            public int[] ids { get; set; }
        }
    }
}
