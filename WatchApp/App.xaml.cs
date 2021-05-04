using System;
using WatchApp.Services;
using WatchApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WatchApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
