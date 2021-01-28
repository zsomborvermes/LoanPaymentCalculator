namespace LoanPaymentCalculator.Core.Models
{
    public class CarLoan : BaseLoan
    {
        public CarLoan(int amount, int durationInYears) : base(amount, durationInYears)
        {
            Interest = 0.06;
        }
    }
}
