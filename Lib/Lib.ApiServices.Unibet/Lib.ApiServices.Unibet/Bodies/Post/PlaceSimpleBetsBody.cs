namespace Lib.ApiServices.Unibet
{
    public class PlaceSimpleBetsBody
    {
        public float[] stakes { get; set; }
        public string[] selections { get; set; }
        public bool isfreebet { get; set; }
        public bool autoConfirm { get; set; }
    }
}
