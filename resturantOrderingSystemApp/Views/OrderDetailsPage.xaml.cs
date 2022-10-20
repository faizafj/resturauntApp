using System;
using Xamarin.Forms.Xaml;
using resturantOrderingSystemApp.Models;
using resturantOrderingSystemApp.ViewModels;
using Xamarin.Forms;
using System.Diagnostics;

namespace resturantOrderingSystemApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailsPage : ContentPage
    {
        public OrderDetailsPage(Models.Order orderDetails)
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<OrderDetailsViewModel>();
            (BindingContext as OrderDetailsViewModel).CurrentOrder = orderDetails;
        }

        protected override async void OnAppearing()
        {
            try
            {
                Console.WriteLine("hello");
                await (BindingContext as OrderDetailsViewModel).GetOrderDetails();
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