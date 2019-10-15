using System;
using System.Collections.Generic;
using UniversalMemo.Models;
using UniversalMemo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversalMemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FolderPage : ContentPage
    {
        FolderViewModel viewModel;
        ListView FoldersListView;
        public FolderPage()
        {
            base.OnAppearing();

            if (viewModel == null)
            {
                viewModel = new FolderViewModel();
            }

            if (viewModel.Folders.Count == 0)
                viewModel.LoadFoldersCommand.Execute(null);

            List<Folder> CurrentFolders;
            new DataEngine(); //lazy init

            if(DataEngine.Folders == null)
            {
                CurrentFolders = DataEngine.getFolders();
            }
            else
            {
                CurrentFolders = DataEngine.Folders;
            }
            FoldersListView = new ListView();
            AddCellData(CurrentFolders);
        }

        public void AddCellData(List<Folder> Folders)
        {

            this.FoldersListView.ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.SetBinding(TextCell.TextProperty, "Text");
                textCell.SetBinding(TextCell.DetailProperty, "Detail");
                return textCell;
            });
            FoldersListView.ItemsSource = Folders;

            // NOTE: use for debugging, not in released app code!
            //foreach (var res in assembly.GetManifestResourceNames()) 
            //	System.Diagnostics.Debug.WriteLine("found resource: " + res);

        }

        private void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var Cellindex = (FoldersListView.ItemsSource as List<Folder>).IndexOf(e.Item as Folder).ToString();
            Folder FolderKey = e.Item as Folder;
           // DataEngine.GetItemsByFolderID(FolderKey.Key);
            Application.Current.MainPage = new ItemsPage(FolderKey.BelongsTo);
        }

        async void AddFolder_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewFolderPage()));
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            Folder folder = args.SelectedItem as Folder;
            if (folder == null)
                return;

            await Navigation.PushAsync(new FolderDetailPage(new FolderDetailViewModel(folder)));

            // Manually deselect item.
            FoldersListView.SelectedItem = null;
        }
    }
}