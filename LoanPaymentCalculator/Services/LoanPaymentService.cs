using System;
using LoanPaymentCalculator.Models;

namespace LoanPaymentCalculator.Services
{
    public class LoanPaymentService
    {

        public double CalculateMonthlyPayment(LoanViewModel form)
        {
            /*
             * Amortized Loan Payment Formula
             * payment = loanAmount / {[(1 + periodicInterestRate)^paymentTimeInMonths] - 1} / [periodicInterestRate * (1 + periodicInterestRate)^paymentTimeInMonths]
             * https://www.thebalance.com/loan-payment-calculations-315564#:~:text=To%20calculate%20the%20monthly%20payment,per%20year%20times%2030%20years
             */

            double periodicInterestRate = 0.06 / 12;
            int paymentTimeInMonths = form.LoanTermInYears * 12;

            double numerator = Math.Pow(1 + periodicInterestRate, paymentTimeInMonths) - 1;
            double denominator = periodicInterestRate * Math.Pow(1 + periodicInterestRate, paymentTimeInMonths);

            double discountFactor = numerator / denominator;

            return form.LoanAmount / discountFactor;
        }
    }
}
