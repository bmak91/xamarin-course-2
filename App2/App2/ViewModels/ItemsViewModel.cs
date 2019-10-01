using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;

using App2.Models;
using App2.Views;
using Newtonsoft.Json;

namespace App2.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        public class Todo
        {
            public string Title { get; set; }
            public bool Completed { get; set; }
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                // var items = await DataStore.GetItemsAsync(true);
                using (var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
                })
                {
                    var response = await httpClient.GetAsync("/todos");
                    // "{\"Property\": \"Value\"}"
                    var json = await response.Content.ReadAsStringAsync();
                    var todos = JsonConvert.DeserializeObject<List<Todo>>(json);

                    foreach (var todo in todos)
                    {
                        Items.Add(new Item
                        {
                            Text = todo.Title,
                            Description = todo.Completed 
                                ? "Completed" : "Not Completed"
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}