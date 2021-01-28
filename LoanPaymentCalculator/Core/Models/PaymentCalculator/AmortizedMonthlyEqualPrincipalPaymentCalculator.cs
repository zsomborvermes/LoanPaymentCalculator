using System;
using System.Collections.Generic;

namespace LoanPaymentCalculator.Core.Models
{
    public class AmortizedMonthlyEqualPrincipalPaymentCalculator : IPaymentCalculator
    {
        private BaseLoan _loan;

        private PaymentFactory _paymentFactory;

        public AmortizedMonthlyEqualPrincipalPaymentCalculator(PaymentFactory paymentFactory)
        {
            _paymentFactory = paymentFactory;
        }

        public List<Payment> CalculatePayments(BaseLoan loan)
        {
            _loan = loan;

            List<Payment> payments = new List<Payment>();

            double amountLeft = _loan.LoanAmount;
            double principal = amountLeft / _loan.LoanTermInMonths;
            double monthlyInterest;
            double payment;

            for (int currentMonth = 1; currentMonth <= _loan.LoanTermInMonths; currentMonth++)
            {
                monthlyInterest = (amountLeft * _loan.Interest) / 12;

                amountLeft = (currentMonth != _loan.LoanTermInMonths) ? amountLeft - principal : 0;

                payment = principal + monthlyInterest;

                Payment paymentToAdd = _paymentFactory.Create(
                    DateTime.Now.AddMonths(currentMonth),
                    payment,
                    principal,
                    monthlyInterest,
                    amountLeft
                    );

                payments.Add(paymentToAdd);
            }

            return payments;
        }
    }
}
