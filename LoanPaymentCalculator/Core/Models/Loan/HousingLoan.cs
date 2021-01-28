using System;
namespace LoanPaymentCalculator.Core.Models
{
    public class HousingLoan : BaseLoan
    {
        public HousingLoan(int amount, int durationInYears) : base(amount, durationInYears)
        {
            Interest = 0.035;
        }
    }
}
