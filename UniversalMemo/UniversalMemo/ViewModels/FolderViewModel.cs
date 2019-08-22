using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using UniversalMemo.Models;
using UniversalMemo.Views;

namespace UniversalMemo.ViewModels
{

    public class FolderViewModel : BaseViewModel
    {
        public ObservableCollection<Folder> Folders { get; set; }
        public Command LoadFoldersCommand { get; set; }
        public FolderViewModel()
        {
            Title = "Folders";
            Folders = new ObservableCollection<Folder>();
            LoadFoldersCommand = new Command(async () => await ExecuteLoadFoldersCommand());

            MessagingCenter.Subscribe<NewFolderPage, Folder>(this, "AddFolder", async (obj, Folder) =>
            {
                var NewFolder = Folder as Folder;
                Folders.Add(NewFolder);
                await FolderDataStore.AddItemAsync(NewFolder);
            });


        }
        async Task ExecuteLoadFoldersCommand()
    {
        if (IsBusy)
            return;

        IsBusy = true;

        try
        {
            Folders.Clear();

            var NewFolders = await FolderDataStore.GetItemsAsync(true);

            foreach (var ForFolder in NewFolders)
            {
                Folders.Add(ForFolder);
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