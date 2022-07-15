using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services;

public class LoanRepository : IRepository<Loan>
{
    readonly DataContext _context;

    public LoanRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Loan> GetAll()
    {
        return _context.Loans.Include(l => l.Books).Include(l => l.Customer);
    }

    public Loan? Get(int id)
    {
        return _context.Loans.Include(l => l.Books).Include(l => l.Customer).FirstOrDefault(l => l.LoanID == id);
    }

    public Loan? Add(Loan entity)
    {
        throw new NotImplementedException();
    }

    public Loan? Update(Loan entity)
    {
        throw new NotImplementedException();
    }

    public Loan? Delete(int id)
    {
        var loan = _context.Loans.FirstOrDefault(l => l.LoanID == id);

        return loan is null ? null : _context.Loans.Remove(loan).Entity;
    }
}