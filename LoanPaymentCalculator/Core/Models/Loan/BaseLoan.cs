using System;
namespace LoanPaymentCalculator.Core.Models
{
    public abstract class BaseLoan
    {
        public int LoanAmount { get; set; }
        public int LoanTermInYears { get; set; }
        public double Interest { get; protected set; }

        public BaseLoan(int amount, int durationInYears)
        {
            LoanAmount = amount;
            LoanTermInYears = durationInYears;
        }

        public int LoanTermInMonths
        {
            get { return LoanTermInYears * 12; }
        }
    }
}
