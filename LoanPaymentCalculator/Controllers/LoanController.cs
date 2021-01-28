using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoanPaymentCalculator.Models;
using LoanPaymentCalculator.Core.Models;
using System;

namespace LoanPaymentCalculator.Controllers
{
    public class LoanController : Controller
    {
        private readonly ILogger<LoanController> _logger;
        private readonly IPaymentCalculator _paymentCalculator;

        public LoanController(ILogger<LoanController> logger, IPaymentCalculator paymentCalculator)
        {
            _logger = logger;
            _paymentCalculator = paymentCalculator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(LoanViewModel form)
        {
            BaseLoan loan = new HousingLoan(form.LoanAmount, form.LoanTermInYears);
            form.Payments = _paymentCalculator.CalculatePayments(loan);
            return View(form);
        }
    }
}
