using Library.Models;
using Library.Services;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("customers/{id:int}")]
public class CustomerController : Controller
{
    readonly IRepository<Customer> _customersRepo;

    public CustomerController(IRepositoryWrapper repository)
    {
        _customersRepo = repository.Customers;
    }

    public IActionResult Index(int id)
    {
        var customer = _customersRepo.Get(id);

        if (customer is null) return NotFound();

        return View(customer);
    }

    [Route("loans")]
    public IActionResult Loans(int id, LoanState? state)
    {
        var customer = _customersRepo.Get(id);

        if (customer is null) return RedirectToAction("Index");

        var loans = customer.Loans.Where(l => state is null || l.State == state);

        return View(new LoansTableViewModel($"{customer.Fullname}'s {(state is not null ? $"{state} Loans" : "Loans")}", loans));
    }
    
    [Route("edit")]
    public IActionResult Edit(int id)
    {
        var customer = _customersRepo.Get(id);

        if (customer is null) return NotFound();

        return View(customer);
    }
    
    [HttpPost]
    [Route("edit")]
    public IActionResult Edit(Customer entity, int id)
    {
        if (!ModelState.IsValid) return NotFound();

        try
        {
            if (_customersRepo.Update(entity) is null)
                return NotFound();
        }
        catch
        {
            return RedirectToAction("Edit", new { id });
        }
        
        return RedirectToAction("Index", new { id });
    }

    [HttpPost]
    [Route("delete")]
    public IActionResult Delete(Customer entity, int id)
    {
        try
        {
            _customersRepo.Delete(id);
        }
        catch
        {
            return RedirectToAction("Edit", new { id });
        }
        
        _customersRepo.Delete(id);

        return RedirectToAction("List", "Customers");
    }
}