using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using resturantOrderingSystemApp.Models;

namespace resturantOrderingSystemApp.Interfaces
{

    public interface  ITableService
    {
        Task<IEnumerable<Table>> GetAvailableTables();

         Task<bool> UpdateTable (Table tableToUpdate);

    }

}

