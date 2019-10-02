using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Models;

namespace App2.Services
{
    public interface IBooksService
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBookById(int id);
    }

    public class BooksService : IBooksService
    {
        private List<Book> books { get; } = new List<Book>
        {
            new Book(1){ Title = "Book 1", Author = new Author("First", "Last")},
            new Book(2){ Title = "Book 2", Author = new Author("Charles", "Dickens")},
            new Book(3){ Title = "Book 3", Author = new Author("Marcel", "Proust")},
            new Book(4){ Title = "Book 4", Author = new Author("Guy", "De Maupassant")},
            new Book(5){ Title = "Book 5", Author = new Author("Bad", "Author")},
            new Book(6){ Title = "Book 6", Author = new Author("Good", "Author")},
        };

        public Task<List<Book>> GetBooks() => Task.FromResult(books);

        public Task<Book> GetBookById(int id) => 
            Task.FromResult(books.FirstOrDefault(b => b.Id == id));
    }
}
