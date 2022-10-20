using Xamarin.Forms;
using System;
using System.Diagnostics;
using Xamarin.Forms.Xaml;
using resturantOrderingSystemApp.ViewModels;

namespace resturantOrderingSystemApp.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<MainPageViewModel>();
        }

        protected override async void OnAppearing()
        {
            try
            {
                Console.WriteLine("hello");
                await (BindingContext as MainPageViewModel).GetOrders();
            }
            catch (Exception e)
            {
                Debug.Fail(e.Message);
            }

        }

        private void LstProducts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var viewmodel = BindingContext as MainPageViewModel;
            viewmodel.orderSelectedCommand.Execute(e.SelectedItem);
        }

    }
}
