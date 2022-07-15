using Library.Models;
using Library.Services;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("loans/{id:int}")]
public class LoanController : Controller
{
    readonly IRepository<Loan> _loansRepo;

    public LoanController(IRepositoryWrapper repository)
    {
        _loansRepo = repository.Loans;
    }

    public IActionResult Index(int id)
    {
        var customer = _loansRepo.Get(id);

        if (customer is null) return NotFound();

        return View(customer);
    }

    [Route("books")]
    public IActionResult Books(int id)
    {
        var loan = _loansRepo.Get(id);

        if (loan is null) return RedirectToAction("List", "Loans");

        return View(new BooksTableViewModel($"Lent Books", loan.Books));
    }
}