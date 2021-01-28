using System;
using System.Collections.Generic;

namespace LoanPaymentCalculator.Core.Models
{
    public class AmortizedMonthlyPaymentCalculator : IPaymentCalculator
    {
        private BaseLoan _loan;

        public List<Payment> CalculatePayments(BaseLoan loan)
        {
            _loan = loan;

            List<Payment> payments = new List<Payment>();

            double monthlyInterest;
            double principal;
            double amountLeft = _loan.LoanAmount;
            double payment = calculateMonthlyPayment();

            for (int i = 1; i <= _loan.LoanTermInMonths; i++)
            {
                monthlyInterest = _loan.Interest / 12 * amountLeft;

                if (i != _loan.LoanTermInMonths)
                {
                    principal = payment - monthlyInterest;
                }
                else
                {
                    principal = amountLeft;
                    payment = amountLeft + monthlyInterest;
                }

                amountLeft -= principal;

                Payment paymentToAdd = new Payment() {
                    NumberOfMonth = i,
                    AmountToPay=Math.Round(payment, 2),
                    Principal=Math.Round(principal, 2),
                    Interest=Math.Round(monthlyInterest, 2),
                    AmountLeft=Math.Round(amountLeft, 2)
                };

                payments.Add(paymentToAdd);
            }
            return payments;
        }

        private double calculateMonthlyPayment()
        {
            /*
             * Amortized Loan Payment Formula
             * payment = loanAmount / {[(1 + periodicInterestRate)^paymentTimeInMonths] - 1} / [periodicInterestRate * (1 + periodicInterestRate)^paymentTimeInMonths]
             * https://www.thebalance.com/loan-payment-calculations-315564#:~:text=To%20calculate%20the%20monthly%20payment,per%20year%20times%2030%20years
             */

            double periodicInterestRate = _loan.Interest / 12;

            double numerator = Math.Pow(1 + periodicInterestRate, _loan.LoanTermInMonths) - 1;
            double denominator = periodicInterestRate * Math.Pow(1 + periodicInterestRate, _loan.LoanTermInMonths);

            double discountFactor = numerator / denominator;

            return Math.Round(_loan.LoanAmount / discountFactor, 2);
        }
    }
}
