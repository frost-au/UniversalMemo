using System;
using System.ComponentModel;
using Xamarin.Forms;
using UniversalMemo.Models;
using UniversalMemo.ViewModels;

namespace UniversalMemo.Views
{
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        public String CurrentFolder { get; set; }
        public Item PageItem;
        public int id;
    

        public ItemsPage(Guid Cellindex)
        {
            //InitializeComponent();
            new DataEngine(); //lazy init
            if(Cellindex != null)
            {
                PageItem = DataEngine.GetItemByID(Cellindex);
            }
            else 
            {
                //TODO Add some message here for no Items
            }
        }
        private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            //var Cellindex = (ItemsListView.ItemsSource as List<Folder>).IndexOf(e.Item as Folder).ToString();
           // Folder FolderKey = e.Item as Folder;
           // Application.Current.MainPage = new ItemsPage(FolderKey.BelongsTo);
        }


        public void OnButtonClicked()
        {

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