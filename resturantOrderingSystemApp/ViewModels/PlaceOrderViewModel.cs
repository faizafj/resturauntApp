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
    public class PlaceOrderViewModel : BaseViewModel
    {
        private readonly IPlaceOrderService _placeOrderService;
        public Command PlaceOrderCommand { get; set; }
        public string errorMessage = "";

        public PlaceOrderViewModel(IPlaceOrderService ApiPlaceOrderService) //command for navigation
        {
            _placeOrderService = ApiPlaceOrderService;
            PlaceOrderCommand = new Command(async () => await PlaceOrder());
        }

        public string orderId
        {
            get => orderId;
            set
            {
                orderId = value;
                OnPropertyChanged(nameof(orderId));
            }
        }

        public string orderStatus
        {
            get => orderStatus;
            set
            {
                orderStatus = value;
                OnPropertyChanged(nameof(orderStatus));
            }
        }

        public string orderTotal
        {
            get => orderTotal;
            set
            {
                orderTotal = value;
                OnPropertyChanged(nameof(orderTotal));
            }
        }

        public string user
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged(nameof(user));
            }
        }

        public string timeOfOrder
        {
            get => timeOfOrder;
            set
            {
                timeOfOrder = value;
                OnPropertyChanged(nameof(timeOfOrder));
            }
        }

        public string itemId
        {
            get => itemId;
            set
            {
                itemId = value;
                OnPropertyChanged(nameof(itemId));
            }
        }

        public long quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(quantity));
            }
        }

        public string date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged(nameof(date));
            }
        }

        public long numberOfPlaces
        {
            get => numberOfPlaces;
            set
            {
                numberOfPlaces = value;
                OnPropertyChanged(nameof(numberOfPlaces));
            }
        }

        private async Task PlaceOrder()
        {
            try
            {
                var placedOrderDetails = new PlaceOrder
                {
                    type = "Orders",
                    attributes = new PlaceOrderData //attributes
                    {
                        orderId = orderId,
                        orderStatus = orderStatus,
                        orderTotal = orderTotal,
                        user = user,
                        timeOfOrder = timeOfOrder,
                        itemId = itemId,
                        quantity = quantity,
                        date = date,
                        numberOfPlaces = numberOfPlaces
                    }

                };

                var SuccessfulOrder = await _placeOrderService.PlaceOrder(placedOrderDetails);
                if (SuccessfulOrder)
                {
                    Console.WriteLine("Success");
                    await Application.Current.MainPage.DisplayAlert("Order Added Successfully", "Order Added Successfully", "Ok");
                }
                else
                {
                    errorMessage = "Check all details";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

}
