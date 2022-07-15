using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models;

public class Book
{
    [Key]
    public int BookID { get; set; }

    [Required(ErrorMessage = "Title has to be set!")]
    [MaxLength(100)]
    public string Title { get; set; } = default!;

    [Required(ErrorMessage = "Genre has to be set!")]
    [MaxLength(32)]
    public string Genre { get; set; } = default!;

    [Required(ErrorMessage = "Author has to be set!")]
    [MaxLength(100)]
    public string Author { get; set; } = default!;

    public int Quantity { get; set; } = default!;

    [NotMapped]
    public int Available => Quantity - Loans.Count(l => l.State != LoanState.Completed);

    public ICollection<Loan> Loans { get; set; } = default!;
}