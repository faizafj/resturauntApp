using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using resturantOrderingSystemApp.Models;

namespace resturantOrderingSystemApp.Interfaces
{

        public interface IOrderService
        {

            Task<IEnumerable<Order>> GetOrders();

            Task<bool> UpdateOrder(Order orderToUpdate);

            Task<OrderDetails> GetOrderDetails(long orderId);

    }
}
