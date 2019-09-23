using System;

using App2.Models;

namespace App2.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        private Item _item;

        public Item Item
        {
            get => _item;
            set
            {
                _item = value;
                OnPropertyChanged();
            }
        }

        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
