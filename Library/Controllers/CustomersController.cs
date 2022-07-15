using Library.Models;
using Library.Services;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[Route("customers")]
public class CustomersController : Controller
{
    readonly IRepository<Customer> _customersRepo;

    public CustomersController(IRepositoryWrapper repository)
    {
        _customersRepo = repository.Customers;
    }

    public IActionResult List()
    {
        return View(new CustomersTableViewModel("Customers", _customersRepo.GetAll()));
    }

    [Route("create")]
    public IActionResult Create()
    {
        return View(new Customer());
    }

    [HttpPost]
    [Route("create")]
    public IActionResult Create(Customer customer)
    {
        if (!ModelState.IsValid) return RedirectToAction("List");

        try
        {
            var result = _customersRepo.Add(customer);

            if (result is null) throw new Exception();

            return RedirectToAction("Index", "Customer", new { id = result.CustomerID });
        }
        catch
        {
            return RedirectToAction("List");
        }
    }

    [HttpPost]
    [Route("{id:int}/delete")]
    public IActionResult Delete(Customer customer, int id)
    {
        try
        {
            _customersRepo.Delete(id);
        }
        catch
        {
            return RedirectToAction("Edit", "Customer", new { id });
        }
        
        _customersRepo.Delete(id);

        return RedirectToAction("List");
    }
}