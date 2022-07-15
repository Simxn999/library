using Library.Models;

namespace Library.ViewModels;

public class CustomersTableViewModel
{
    public CustomersTableViewModel(string title, IEnumerable<Customer> customers)
    {
        Title = title;
        Customers = customers;
    }
    public string Title { get; set; }
    public IEnumerable<Customer> Customers { get; set; }
}