using System;
namespace LoanPaymentCalculator.Core.Models
{
    public class LoanFactory
    {
        public BaseLoan Create(int amount, int durationInYears)
        {
            return new HousingLoan(amount, durationInYears);
        }
    }
}
