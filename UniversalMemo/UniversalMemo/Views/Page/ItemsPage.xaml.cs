using System;
using System.ComponentModel;
using Xamarin.Forms;
using UniversalMemo.Models;
using UniversalMemo.ViewModels;
using System.Collections.Generic;

namespace UniversalMemo.Views
{
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        public String CurrentFolder { get; set; }
        public int id;

     //   public ItemsPage()
     //   {

       //     InitializeComponent();

       //     base.OnAppearing();

        //    if (viewModel == null)
        //    {
        //        viewModel = new ItemsViewModel();
        //    }

        //    if (viewModel.Items.Count == 0)
         //       viewModel.LoadItemsCommand.Execute(null);

         //   List<Item> CurrentFolders;
         //   new DataEngine(); //lazy init

         //   if (DataEngine.Items == null)
          //  {
          //      CurrentFolders = DataEngine.getItems();
         //   }
         //   else
         //   {
        //        CurrentFolders = DataEngine.Items;
        //    }
      //      AddCellData(CurrentFolders);

      //      AddCellData(DataEngine.Items);
     //   }
        

        public ItemsPage(Guid Cellindex)
        {
            InitializeComponent();
            new DataEngine(); //lazy init
            if(Cellindex != null)
            {
                Item Results = DataEngine.GetItemByID(Cellindex);
            }
            else
            {
                //TODO Add some message here for no Items
            }
            
        }

        public void AddCellData(List<Item> Items)
        {
            ItemsListView.ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.SetBinding(TextCell.TextProperty, "Text");
                textCell.SetBinding(TextCell.DetailProperty, "Detail");
                return textCell;
            });
            ItemsListView.ItemsSource = Items;

            // NOTE: use for debugging, not in released app code!
            //foreach (var res in assembly.GetManifestResourceNames()) 
            //	System.Diagnostics.Debug.WriteLine("found resource: " + res);
        }

        public void AddCellData(List<Folder> Folders)
        {
            ItemsListView.ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.SetBinding(TextCell.TextProperty, "Text");
                textCell.SetBinding(TextCell.DetailProperty, "Detail");
                return textCell;
            });
            ItemsListView.ItemsSource = Folders;

            // NOTE: use for debugging, not in released app code!
            //foreach (var res in assembly.GetManifestResourceNames()) 
            //	System.Diagnostics.Debug.WriteLine("found resource: " + res);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            System.Type Type = args.SelectedItem.GetType();

            if (Type == typeof(Item))
            {
               Item item  =  args.SelectedItem as Item;
               await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
               if (item == null)
                    return;
            }
            else if (Type == typeof(Folder))
            {
                Folder item = args.SelectedItem as Folder;
                await Navigation.PushAsync(new FolderDetailPage(new FolderDetailViewModel(item)));
                if (item == null)
                    return;
            }

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            Folder hit = (Folder)sender;
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage(hit)));
        }

        private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var Cellindex = (ItemsListView.ItemsSource as List<Folder>).IndexOf(e.Item as Folder).ToString();
            Folder FolderKey = e.Item as Folder;
            Application.Current.MainPage = new ItemsPage(FolderKey.BelongsTo);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel == null)
            {
                viewModel = new ItemsViewModel();
            }

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }  
            // NOTE: use for debugging, not in released app code!
            //foreach (var res in assembly.GetManifestResourceNames()) 
            //	System.Diagnostics.Debug.WriteLine("found resource: " + res);
    }
}