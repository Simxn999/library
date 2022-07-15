using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services;

public class CustomerRepository : IRepository<Customer>
{
    readonly DataContext _context;

    public CustomerRepository(DataContext context)
    {
        _context = context;
    }

    public IEnumerable<Customer> GetAll()
    {
        return _context.Customers.Include(c => c.Loans);
    }

    public Customer? Get(int id)
    {
        return _context.Customers.Include(c => c.Loans).ThenInclude(l => l.Books).FirstOrDefault(c => c.CustomerID == id);
    }

    public Customer? Add(Customer entity)
    {
        var customer = _context.Customers.Add(entity);

        _context.SaveChanges();

        return customer.Entity;
    }

    public Customer? Update(Customer entity)
    {
        var customer = Get(entity.CustomerID);

        if (customer is null) return null;

        customer.Name = entity.Name;
        customer.Surname = entity.Surname;
        customer.PhoneNumber = entity.PhoneNumber;
        customer.Email = entity.Email;

        _context.SaveChanges();

        return customer;
    }

    public Customer? Delete(int id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);

        if (customer is null) return null;

        var result = _context.Customers.Remove(customer);

        _context.SaveChanges();

        return result.Entity;
    }
}