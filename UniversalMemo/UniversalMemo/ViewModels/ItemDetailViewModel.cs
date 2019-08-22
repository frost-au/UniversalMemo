using UniversalMemo.Models;

namespace UniversalMemo.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item.Name;
            Item = item;
        }
    }
}
