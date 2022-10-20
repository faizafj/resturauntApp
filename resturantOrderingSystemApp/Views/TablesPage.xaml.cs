using Xamarin.Forms;
using System;
using System.Diagnostics;
using Xamarin.Forms.Xaml;
using resturantOrderingSystemApp.ViewModels;


namespace resturantOrderingSystemApp.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablesPage : ContentPage
    {

        public TablesPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<TablesViewModel>();
        }

        protected override async void OnAppearing()
        {
            try
            {
                Console.WriteLine("hello");
                await (BindingContext as TablesViewModel).GetAvailableTables();
            }
            catch (Exception e)
            {
                Debug.Fail(e.Message);
            }

        }


        private void LstMenuItem_TableSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var viewmodel = BindingContext as TablesViewModel;
            viewmodel.tableSelectedCommand.Execute(e.SelectedItem);
        }

    }
}
