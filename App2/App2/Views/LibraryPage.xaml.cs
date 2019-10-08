using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibraryPage : ContentPage
    {
        private LibraryViewModel VM { get; set; }
        public LibraryPage()
        {
            InitializeComponent();

            VM = new LibraryViewModel((selectedBook) =>
            {
                Navigation.PushAsync(new ContentPage()
                {

                });
            });
            BindingContext = VM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            VM.LoadData(true);
        }
    }
}