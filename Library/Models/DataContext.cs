using Microsoft.EntityFrameworkCore;

namespace Library.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options) { }
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Loan> Loans => Set<Loan>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
                    .HasData(new Customer
                    {
                        CustomerID = 1,
                        Name = "Simon",
                        Surname = "Johansson",
                        PhoneNumber = "123 456 78 91",
                        Email = "simon.johansson@mail.com",
                    });
        modelBuilder.Entity<Customer>()
                    .HasData(new Customer
                    {
                        CustomerID = 2,
                        Name = "Elon",
                        Surname = "Musk",
                        PhoneNumber = "123 456 78 92",
                        Email = "elon.musk@mail.com",
                    });
        modelBuilder.Entity<Customer>()
                    .HasData(new Customer
                    {
                        CustomerID = 3,
                        Name = "Rebecca",
                        Surname = "Gerdin",
                        PhoneNumber = "123 456 78 93",
                        Email = "rebecca.gerdin@mail.com",
                    });

        modelBuilder.Entity<Book>()
                    .HasData(new Book
                    {
                        BookID = 1,
                        Title = "Mice in Heaven",
                        Author = "Buddy The Cat",
                        Genre = "Adventure",
                        Quantity = 999,
                    });
        modelBuilder.Entity<Book>()
                    .HasData(new Book
                    {
                        BookID = 2,
                        Title = "Archer AX50 User Guide",
                        Author = "TP-Link",
                        Genre = "Romantic",
                        Quantity = 3,
                    });

        modelBuilder.Entity<Loan>()
                    .HasData(new Loan
                    {
                        LoanID = 1,
                        InitiatedDate = new DateTime(2022, 07, 12),
                        DueDate = new DateTime(2022, 07, 27),
                        CustomerID = 1,
                        IsReturned = true,
                    });
        modelBuilder.Entity<Loan>()
                    .HasData(new Loan
                    {
                        LoanID = 2,
                        InitiatedDate = new DateTime(2022, 05, 13),
                        DueDate = new DateTime(2022, 05, 27),
                        CustomerID = 2,
                    });
        modelBuilder.Entity<Loan>()
                    .HasData(new Loan
                    {
                        LoanID = 3,
                        InitiatedDate = new DateTime(2022, 09, 27),
                        DueDate = new DateTime(2023, 06, 30),
                        CustomerID = 3,
                    });

        modelBuilder.Entity("BookLoan").HasData(new { BooksBookID = 2, LoansLoanID = 1, });
        modelBuilder.Entity("BookLoan").HasData(new { BooksBookID = 1, LoansLoanID = 2, });
        modelBuilder.Entity("BookLoan").HasData(new { BooksBookID = 1, LoansLoanID = 3, });
    }
}