using UniversalMemo.Models;

namespace UniversalMemo.ViewModels
{
    public class FolderDetailViewModel : BaseViewModel
    {
        public Folder Folder { get; set; }
        public FolderDetailViewModel(Folder NewFolder = null)
        {
            Title = Folder.Text;
            Folder = NewFolder;
        }

        public FolderDetailViewModel()
        {

        }

    }
}
