using System;
using Microsoft.Extensions.DependencyInjection;

namespace resturantOrderingSystemApp
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider Init()
        {
            ServiceProvider serviceProvider;

            serviceProvider = new ServiceCollection()
            .ConfigureServices()
            .ConfigureViewModels()
            .BuildServiceProvider();

            ServiceProvider = serviceProvider;

            return serviceProvider;
        }
    }
}
