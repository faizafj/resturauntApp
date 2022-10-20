using System;
using Xamarin.Forms;
using resturantOrderingSystemApp.Views;
using resturantOrderingSystemApp.Interfaces;
using resturantOrderingSystemApp.Models;
using resturantOrderingSystemApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace resturantOrderingSystemApp.ViewModels

{
    public class OrderDetailsViewModel : BaseViewModel
    {
        private readonly IOrderService _orderService;
        public ObservableCollection<OrderDetails> orderDetail { get; set; }
        public Order _currentOrder;
        public OrderDetails _currentDetails;

        public ObservableCollection<OrderDetails> order //defines orderDetails var and adds methods
        {
            get => order;
            set
            {
                order = value;
                OnPropertyChanged(nameof(Order));
            }
        }


        public async Task GetOrderDetails() //gets all the orders
        {
            try
            {
                CurrentDetails = await _orderService.GetOrderDetails(CurrentOrder.orderId); //retrieves all the orders
                Console.WriteLine(CurrentDetails);
            }
            catch (Exception ex) //if its not working, throws an error
            {
                Console.WriteLine(ex.Message);
            }
        }


        public Order CurrentOrder
        {
            get => _currentOrder;
            set
            {
                _currentOrder = value;
                OnPropertyChanged(nameof(CurrentOrder));
            }
        }

        public OrderDetails CurrentDetails
        {
            get => _currentDetails;
            set
            {
                _currentDetails = value;
                OnPropertyChanged(nameof(CurrentDetails));
            }
        }

        public OrderDetailsViewModel(IOrderService orderService)
        {
            _orderService = orderService;

        }
    }
}

