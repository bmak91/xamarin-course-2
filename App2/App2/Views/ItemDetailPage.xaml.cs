﻿using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App2.Models;
using App2.ViewModels;

namespace App2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    [QueryProperty("Title", "title")]
    [QueryProperty("Description", "description")]
    public partial class ItemDetailPage : ContentPage
    {
        private ItemDetailViewModel ViewModel { get; set; } = 
            new ItemDetailViewModel(new Item
        {
            Description = "This is an item description."
        });

        public string Title
        {
            set =>
                ViewModel.Item
                    = new Item
                    {
                        Text = Uri.UnescapeDataString(value),
                        Description = ViewModel.Item.Description
                    };
        }
        public string Description
        {
            set =>
                ViewModel.Item
            = new Item
            {
                Text = ViewModel.Item.Text,
                Description = Uri.UnescapeDataString(value)
            };
        }

        public ItemDetailPage(ItemDetailViewModel viewModel)
        : this()
        {
            ViewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }
    }
}