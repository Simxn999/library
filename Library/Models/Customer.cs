using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Library.Models;

public class Customer
{
    [Key]
    public int CustomerID { get; set; }

    [Required(ErrorMessage = "Name has to be set!")]
    [MaxLength(50)]
    public string Name { get; set; } = default!;

    [Required(ErrorMessage = "Surname has to be set!")]
    [MaxLength(50)]
    public string Surname { get; set; } = default!;

    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Phone Number has to be set!")]
    [MaxLength(32)]
    public string PhoneNumber { get; set; } = default!;

    [DataType(DataType.EmailAddress)]
    [MaxLength(100)]
    [DisplayFormat(NullDisplayText = "N/A")]
    public string? Email { get; set; }

    [ValidateNever]
    public ICollection<Loan> Loans { get; set; } = default!;

    [NotMapped]
    public string Fullname => $"{Name} {Surname}";
}