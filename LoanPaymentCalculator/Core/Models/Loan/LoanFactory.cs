using System;
namespace LoanPaymentCalculator.Core.Models
{
    public class LoanFactory
    {
        public BaseLoan CreateHousingLoan(int loanAmount, int loanTermInYears)
        {
            return new HousingLoan(loanAmount, loanTermInYears);
        }

        public BaseLoan CreateCarLoan(int loanAmount, int loanTermInYears)
        {
            return new CarLoan(loanAmount, loanTermInYears);
        }
    }
}
