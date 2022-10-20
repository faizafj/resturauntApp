using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using resturantOrderingSystemApp.Models;

namespace resturantOrderingSystemApp.Interfaces
{

    public interface IMenuService
    {

        Task<IEnumerable<MenuItem>> GetMenuItems();

        Task<MenuItemDetails> GetMenuItemDetails(long itemId);

    }
}
