using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UniversalMemo.Services;
using UniversalMemo.Views;

namespace UniversalMemo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockFoldersDataStore>();
            DependencyService.Register<MockItemsDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
