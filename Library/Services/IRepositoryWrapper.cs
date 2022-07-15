using Library.Models;

namespace Library.Services;

public interface IRepositoryWrapper
{
    IRepository<Book> Books { get; }
    IRepository<Customer> Customers { get; }
    IRepository<Loan> Loans { get; }
}