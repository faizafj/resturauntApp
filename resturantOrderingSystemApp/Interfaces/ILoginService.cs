using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using resturantOrderingSystemApp.Models;

namespace resturantOrderingSystemApp.Interfaces
{

    public interface ILoginService
    {

        Task <bool> Login (Account accountDetails);

    }
}
