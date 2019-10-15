using System;
using System.ComponentModel;
using Xamarin.Forms;
using UniversalMemo.Models;

namespace UniversalMemo.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer

    [DesignTimeVisible(false)]

    public partial class NewFolderPage : ContentPage
    {
        public Folder Folder { get; set; }
        public NewFolderPage()
        {
            InitializeComponent();

            Folder = new Folder
            {
                Text = "Folder name",
                Detail = DateTime.Now
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddFolder", Folder);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}