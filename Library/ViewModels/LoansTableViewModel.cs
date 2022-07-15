using Library.Models;

namespace Library.ViewModels;

public class LoansTableViewModel
{
    public LoansTableViewModel(string title, IEnumerable<Loan> loans)
    {
        Title = title;
        Loans = loans;
    }
    public string Title { get; set; }
    public IEnumerable<Loan> Loans { get; set; }
}