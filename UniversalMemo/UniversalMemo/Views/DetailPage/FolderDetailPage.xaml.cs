using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalMemo.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


//TODO: Delete this
namespace UniversalMemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FolderDetailPage : ContentPage
    {
        public FolderDetailViewModel FolderDVModel;

        public FolderDetailPage(FolderDetailViewModel NewFolderModel = null)
        {
            this.FolderDVModel = NewFolderModel;
            InitializeComponent();
        }
    
        public FolderDetailPage(String Key)
        {
            InitializeComponent();
        }
    }
}