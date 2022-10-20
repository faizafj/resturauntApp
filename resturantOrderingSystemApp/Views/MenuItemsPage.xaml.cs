using Xamarin.Forms;
using System;
using System.Diagnostics;
using Xamarin.Forms.Xaml;
using resturantOrderingSystemApp.ViewModels;


namespace resturantOrderingSystemApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuItemsPage : ContentPage
    {
        public MenuItemsPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<MenuItemsViewModel>();
        }

        protected override async void OnAppearing()
        {
            try
            {
                Console.WriteLine("hello");
                await (BindingContext as MenuItemsViewModel).GetMenuItems();
            }
            catch (Exception e)
            {
                Debug.Fail(e.Message);
            }

        }

        private void LstMenuItem_MenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var viewmodel = BindingContext as MenuItemsViewModel;
            viewmodel.menuItemSelectedCommand.Execute(e.SelectedItem);
        }
    }
}
