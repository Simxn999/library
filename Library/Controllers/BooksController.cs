using Library.Models;
using Library.Services;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("books")]
public class BooksController : Controller
{
    readonly IRepository<Book> _booksRepo;

    public BooksController(IRepositoryWrapper repository)
    {
        _booksRepo = repository.Books;
    }

    public IActionResult List()
    {
        return View(new BooksTableViewModel("Books", _booksRepo.GetAll()));
    }
}