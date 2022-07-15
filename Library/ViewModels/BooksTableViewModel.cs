using Library.Models;

namespace Library.ViewModels;

public class BooksTableViewModel
{
    public BooksTableViewModel(string title, IEnumerable<Book> books)
    {
        Title = title;
        Books = books;
    }
    public string Title { get; set; }
    public IEnumerable<Book> Books { get; set; }
}