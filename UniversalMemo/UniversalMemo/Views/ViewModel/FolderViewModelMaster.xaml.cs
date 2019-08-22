using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversalMemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoladerViewModelMaster : ContentPage
    {
        public ListView ListView;

        public FoladerViewModelMaster()
        {
            InitializeComponent();

            BindingContext = new FoladerViewModelMasterViewModel();
            ListView = MenuItemsListView;
        }

        class FoladerViewModelMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FoladerViewModelMasterMenuItem> MenuItems { get; set; }

            public FoladerViewModelMasterViewModel()
            {
                MenuItems = new ObservableCollection<FoladerViewModelMasterMenuItem>(new[]
                {
                    new FoladerViewModelMasterMenuItem { Id = 0, Title = "Page 1" },
                    new FoladerViewModelMasterMenuItem { Id = 1, Title = "Page 2" },
                    new FoladerViewModelMasterMenuItem { Id = 2, Title = "Page 3" },
                    new FoladerViewModelMasterMenuItem { Id = 3, Title = "Page 4" },
                    new FoladerViewModelMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}