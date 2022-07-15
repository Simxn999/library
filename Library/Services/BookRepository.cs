using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services;

public class BookRepository : IRepository<Book>
{
    readonly DataContext _context;

    public BookRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Book> GetAll()
    {
        return _context.Books.Include(b => b.Loans);
    }

    public Book? Get(int id)
    {
        return _context.Books.Include(b => b.Loans).ThenInclude(l => l.Customer).FirstOrDefault(b => b.BookID == id);
    }

    public Book? Add(Book entity)
    {
        throw new NotImplementedException();
    }

    public Book? Update(Book entity)
    {
        throw new NotImplementedException();
    }

    public Book? Delete(int id)
    {
        var book = _context.Books.FirstOrDefault(b => b.BookID == id);

        return book is null ? null : _context.Books.Remove(book).Entity;
    }
}