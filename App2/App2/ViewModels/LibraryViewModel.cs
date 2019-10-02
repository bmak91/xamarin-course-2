using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Models;
using App2.Services;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class LibraryViewModel : BaseViewModel
    {
        private readonly IBooksService _booksService;
        public LibraryViewModel()
        {
            _booksService = DependencyService.Resolve<IBooksService>();
        }

        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();

        public async Task LoadData()
        {
            var books = await _booksService.GetBooks();
            foreach (var book in books)
            {
                Books.Add(book);
            }
        }
    }
}
