using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App2.Models;
using App2.Services;
using Xamarin.Forms;

namespace App2.ViewModels
{
    public class LibraryViewModel : BaseViewModel
    {
        public ICommand SelectionChangedCommand { get; private set; }

        public Book SelectedBook { get; set; }

        private readonly IBooksService _booksService;
        public LibraryViewModel(Action<Book> navigate)
        {
            _booksService = DependencyService.Resolve<IBooksService>();
            SelectionChangedCommand = new Command(() =>
            {
                navigate(SelectedBook);
            });
        }

        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();

        public async Task LoadData(bool shouldClearData)
        {
            if (shouldClearData)
            {
                Books.Clear();
            }

            IsBusy = true;
            var books = await _booksService.GetBooks();
            foreach (var book in books)
            {
                Books.Add(book);
            }
            IsBusy = false;
        }
    }
}
