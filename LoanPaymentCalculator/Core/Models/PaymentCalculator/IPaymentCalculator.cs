using System;
using System.Collections.Generic;

namespace LoanPaymentCalculator.Core.Models
{
    public interface IPaymentCalculator
    {
        public List<Payment> CalculatePayments(BaseLoan loan);
    }
}
