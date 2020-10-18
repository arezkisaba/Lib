namespace Lib.ApiServices.Unibet
{
    public class PlaceMultipleBetsBody
    {
        public float stake { get; set; }
        public string[] selections { get; set; }
        public bool isfreebet { get; set; }
        public bool autoConfirm { get; set; }
    }
}
