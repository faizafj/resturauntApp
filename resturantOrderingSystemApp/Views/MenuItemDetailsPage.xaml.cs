using System;
using Xamarin.Forms.Xaml;
using resturantOrderingSystemApp.Models;
using resturantOrderingSystemApp.ViewModels;
using Xamarin.Forms;
using System.Diagnostics;

namespace resturantOrderingSystemApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuItemDetailsPage : ContentPage
    {
        public MenuItemDetailsPage(Models.MenuItem menuItemDetails)
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<MenuItemsDetailsViewModel>();
            (BindingContext as MenuItemsDetailsViewModel).CurrentMenuItem = menuItemDetails;
        }

        protected override async void OnAppearing()
        {
            try
            {
                Console.WriteLine("hello");
                await (BindingContext as MenuItemsDetailsViewModel).GetMenuItemDetails();
            }
            catch (Exception e)
            {
                Debug.Fail(e.Message);
            }

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var list = (ListView)sender;
            list.SelectedItem = null;
        }
    }
}
