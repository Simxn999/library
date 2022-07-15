using Library.Models;
using Library.Services;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("loans")]
public class LoansController : Controller
{
    readonly IRepository<Loan> _loansRepo;

    public LoansController(IRepositoryWrapper repository)
    {
        _loansRepo = repository.Loans;
    }

    public IActionResult List()
    {
        return View(new LoansTableViewModel("Loans", _loansRepo.GetAll()));
    }
}