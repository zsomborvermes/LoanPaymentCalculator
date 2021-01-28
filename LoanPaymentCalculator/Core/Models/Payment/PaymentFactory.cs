using System;
namespace LoanPaymentCalculator.Core.Models
{
    public class PaymentFactory
    {
        public Payment Create(DateTime date, double payment, double principal, double monthlyInterest, double amountLeft)
        {

            return new Payment()
            {
                Date = date.ToString("MMM yyyy"),
                AmountToPay = Math.Round(payment, 2),
                Principal = Math.Round(principal, 2),
                Interest = Math.Round(monthlyInterest, 2),
                AmountLeft = Math.Round(amountLeft, 2)
            };
        }
    }
}
