using System;
using System.ComponentModel;
using Xamarin.Forms;
using UniversalMemo.Models;

namespace UniversalMemo.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer

    [DesignTimeVisible(false)]

    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        public NewItemPage(Folder ContainerFolder)
        {
            InitializeComponent();


            Item = new Item
            {
                Name = "Item name",
                Description = "This is an item description.",
                Body = "This is a very large amount of text\n It should be on multiple lines\n yay",
                BelongsTo = ContainerFolder.BelongsTo
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}