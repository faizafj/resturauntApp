using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using resturantOrderingSystemApp.Models;

namespace resturantOrderingSystemApp.Interfaces
{

    public interface IPlaceOrderService
    {

        Task<bool> PlaceOrder(PlaceOrder placedOrder);

    }
}
