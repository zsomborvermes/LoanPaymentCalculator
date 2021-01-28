using Microsoft.AspNetCore.Mvc;
using LoanPaymentCalculator.ViewModels;
using LoanPaymentCalculator.Core.Models;

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
        public IActionResult Index(LoanViewModel model)
        {
            BaseLoan loan = _loanFactory.CreateHousingLoan(model.LoanAmount, model.LoanTermInYears);
            model.Payments = _paymentCalculator.CalculatePayments(loan);
            return View(model);
        }
    }
}
