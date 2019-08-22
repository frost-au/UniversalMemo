using System;
using UniversalMemo.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversalMemo.Views.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentView
    {
        public ItemPage(Guid ItemKey)
        {
            InitializeComponent();
            Item PageData = DataEngine.GetItemByID(ItemKey);
            AddCellData()

        }

        //TODO Workout how to how to binding correctly. 

        public DataTemplate ItemTemplate { get; private set; }

        public void AddCellData(Item Items)
        {
            Item
                this.ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.SetBinding(TextCell.TextProperty, "Text");
                textCell.SetBinding(TextCell.DetailProperty, "Detail");
                return textCell;
            });

            this.ItemTemplate. = Folders;

            // NOTE: use for debugging, not in released app code!
            //foreach (var res in assembly.GetManifestResourceNames()) 
            //	System.Diagnostics.Debug.WriteLine("found resource: " + res);

        }
    }
}