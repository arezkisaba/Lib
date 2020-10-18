namespace Lib.ApiServices.Unibet
{
    public class AddBetBody
    {
        public string selectionId { get; set; }
        public string priceUp { get; set; }
        public string priceDown { get; set; }
        public string priceType { get; set; }
    }
}
