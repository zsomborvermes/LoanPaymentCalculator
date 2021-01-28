using System;
namespace LoanPaymentCalculator.Core.Models
{
    public abstract class BaseLoan
    {
        public int LoanAmount { get; set; }
        public int LoanTermInYears { get; set; }
        public double Interest { get; protected set; }

        public BaseLoan(int loanAmount, int loanTermInYears)
        {
            LoanAmount = loanAmount;
            LoanTermInYears = loanTermInYears;
        }

        public int LoanTermInMonths
        {
            get { return LoanTermInYears * 12; }
        }
    }
}
