using System;
using resturantOrderingSystemApp.Navigation;
using Xamarin.Essentials;
using resturantOrderingSystemApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace resturantOrderingSystemApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Startup.Init();
            MainPage = new NavigationPage(new Views.TabbedNavPage());
            NavigationDispatcher.Instance.Initialize(MainPage.Navigation);
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