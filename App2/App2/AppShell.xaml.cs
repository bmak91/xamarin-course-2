using System;
using System.Collections.Generic;
using App2.Views;
using Xamarin.Forms;

namespace App2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("items/details", typeof(ItemDetailPage));
        }
    }
}
