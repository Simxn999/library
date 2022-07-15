using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models;

public class Loan
{
    [Key]
    [Display(Name = "Loan ID")]
    public int LoanID { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Start Date")]
    public DateTime InitiatedDate { get; init; } = DateTime.UtcNow;
    [Display(Name = "Due Date")]
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Due Date has to be set!")]
    public DateTime DueDate { get; set; } = default!;

    public int CustomerID { get; set; }
    [Display(Name = "Borrower")]
    public Customer Customer { get; set; } = default!;

    public ICollection<Book> Books { get; set; } = default!;

    public bool IsReturned { get; set; } = false;

    [NotMapped]
    public LoanState State
    {
        get
        {
            if (IsReturned)
                return LoanState.Completed;

            if (DueDate.ToUniversalTime().Subtract(DateTime.UtcNow).Days <= 0)
                return LoanState.Expired;

            return LoanState.Active;
        }
    }

    [NotMapped]
    public string Title => $"Loan #{LoanID} - {Customer.Fullname}";
}