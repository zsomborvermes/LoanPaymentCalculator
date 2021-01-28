using System.Collections.Generic;
using System.ComponentModel;
using LoanPaymentCalculator.Core.Models;

namespace LoanPaymentCalculator.Models
{
    public class LoanViewModel
    {
        [DisplayName("Loan amount: ")]
        public int LoanAmount { get; set; }

        [DisplayName("Loan term in years")]
        public int LoanTermInYears { get; set; }

        public List<Payment> Payments { get; set; }
    }
}
