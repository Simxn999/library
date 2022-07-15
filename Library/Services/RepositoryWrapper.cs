using Library.Models;

namespace Library.Services;

public class RepositoryWrapper : IRepositoryWrapper
{
    readonly DataContext _context;
    IRepository<Book>? _books;
    IRepository<Customer>? _customers;
    IRepository<Loan>? _loans;

    public RepositoryWrapper(DataContext context)
    {
        _context = context;
    }

    public IRepository<Book> Books => _books ??= new BookRepository(_context);
    public IRepository<Customer> Customers => _customers ??= new CustomerRepository(_context);
    public IRepository<Loan> Loans => _loans ??= new LoanRepository(_context);
}