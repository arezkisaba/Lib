namespace Lib.ApiServices.Transmission
{
    public class RemoveTorrentBody
    {
        public string method { get; set; }
        public Arguments arguments { get; set; }

        public class Arguments
        {
            public int[] ids { get; set; }
        }
    }
}
