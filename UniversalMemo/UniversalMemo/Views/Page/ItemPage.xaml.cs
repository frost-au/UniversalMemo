using System;
using UniversalMemo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversalMemo.Views.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentView
    {
        Item item;
        public ItemPage(Guid ItemKey)
        {
           InitializeComponent();
           item = DataEngine.GetItemByID(ItemKey);
        }

        ItemPage()
        {

        }
        //TODO Workout how to how to binding correctly. 

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage(DataEngine.GetFolderByID(item.BelongsTo))));
        }

        public DataTemplate ItemTemplate { get; private set; }

        //TODO: WOrk out if this is needed below.

      //  public void AddCellData(Item Items)
      //  {

        //    ItemPage.ItemTemplate = new DataTemplate(() =>
        //    {
         //       var textCell = new TextCell();
         //       textCell.SetBinding(TextCell.TextProperty, "Text");
          //      textCell.SetBinding(TextCell.DetailProperty, "Detail");
          //      return textCell;
           // });

          //  ItemPage.ItemsSource = Items;

            // NOTE: use for debugging, not in released app code!
            //foreach (var res in assembly.GetManifestResourceNames()) 
            //	System.Diagnostics.Debug.WriteLine("found resource: " + res);
       // }
    }
}