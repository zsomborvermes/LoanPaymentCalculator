using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LoanPaymentCalculator.Models;
using LoanPaymentCalculator.Core.Models;
using System;

namespace LoanPaymentCalculator.Controllers
{
    public class LoanController : Controller
    {
        private readonly IPaymentCalculator _paymentCalculator;
        private readonly LoanFactory _loanFactory;

        public LoanController(IPaymentCalculator paymentCalculator, LoanFactory loanFactory)
        {
            _paymentCalculator = paymentCalculator;
            _loanFactory = loanFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(LoanViewModel form)
        {
            BaseLoan loan = _loanFactory.CreateHousingLoan(form.LoanAmount, form.LoanTermInYears);
            form.Payments = _paymentCalculator.CalculatePayments(loan);
            return View(form);
        }
    }
}
