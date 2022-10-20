using resturantOrderingSystemApp.Navigation;
using Xamarin.Forms;
using resturantOrderingSystemApp.Views;
using resturantOrderingSystemApp.Interfaces;
using resturantOrderingSystemApp.Models;
using resturantOrderingSystemApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System;

namespace resturantOrderingSystemApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel

    {
        public ObservableCollection<Order> orders { get; set; }
        public Order SelectedItem { get; set; }
        public Command viewOrdersCommand { get; set; } //gets and set the viewOrdersPage command so that the page changes
        public Command ViewAllOrders { get; set; }
        private readonly IOrderService _orderService;
        public Command orderSelectedCommand { get; set; }


        public MainPageViewModel(IOrderService ApiOrderService) //command for navigation
        {
            viewOrdersCommand = new Command(viewOrdersPage);
            _orderService = ApiOrderService;
            Orders = new ObservableCollection<Order>();
            orderSelectedCommand = new Command<Order>(orderSelected);
        }

        private void viewOrdersPage() //pushes the nextPage which is orders
        {
            var nextPage = new Orders();
            NavigationDispatcher.Instance.Navigation.PushAsync(nextPage);

        }

        public ObservableCollection<Order> Orders //defines orders var and adds methods
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        public async Task GetOrders() //gets all the orders
        {
            try
            {
                Orders.Clear(); //clears anything that was there before

                var retrievedOrders = await _orderService.GetOrders(); //retrieves all the orders
                foreach (var order in retrievedOrders)
                {
                    if (order.attributes.orderStatus == "Placed" || order.attributes.orderStatus == "Ready")
                    {
                        Orders.Add(order);
                    }
                }
            }
            catch (Exception ex) //if its not working, throws an error
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void orderSelected(Order selectedOrder)
        {
            Console.WriteLine("orderSelected");
            var newPage = new OrderDetailsPage(selectedOrder);
            NavigationDispatcher.Instance.Navigation.PushAsync(newPage);

        }
    }
}
