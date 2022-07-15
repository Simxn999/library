using Library.Models;
using Library.Services;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("books/{id:int}")]
public class BookController : Controller
{
    readonly IRepository<Book> _booksRepo;

    public BookController(IRepositoryWrapper repository)
    {
        _booksRepo = repository.Books;
    }

    public IActionResult Index(int id)
    {
        var book = _booksRepo.Get(id);

        if (book is null) return RedirectToAction("List", "Books");

        return View(book);
    }

    [Route("loans")]
    public IActionResult Loans(int id, LoanState? state)
    {
        var book = _booksRepo.Get(id);

        if (book is null) return RedirectToAction("Index");

        var loans = book.Loans.Where(l => state is null || l.State == state);

        return View(new LoansTableViewModel($"Book {book.Title}'s {(state is not null ? $"{state} Loans" : "Loans")}", loans));
    }
}