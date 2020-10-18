namespace Lib.ApiServices.Unibet
{
    public class ConfirmBetsBody
    {
        public string betslipId { get; set; }
        public string betslipkey { get; set; }
        public bool clearAfterConfirm { get; set; }
    }
}
