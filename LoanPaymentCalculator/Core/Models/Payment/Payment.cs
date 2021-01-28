namespace LoanPaymentCalculator.Core.Models
{
    public class Payment
    {
        public string Date { get; set; }
        public double AmountToPay { get; set; }
        public double Interest { get; set; }
        public double Principal { get; set; }
        public double AmountLeft { get; set; }

    }
}
