using System;
using resturantOrderingSystemApp.Interfaces;
using resturantOrderingSystemApp.Services;
using resturantOrderingSystemApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace resturantOrderingSystemApp
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices (this IServiceCollection services)
        {
            services.AddSingleton<IOrderService, ApiOrderService>();
            services.AddSingleton<IMenuService, ApiMenuService>();
            services.AddSingleton<ITableService, ApiTableService>();
            services.AddSingleton<IPlaceOrderService, ApiPlaceOrderService>();
            services.AddSingleton<ILoginService, ApiLoginService>();


            return services;

        }

        public static IServiceCollection ConfigureMockServices(this IServiceCollection services)
        {
            return services;
        }


        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddTransient<MainPageViewModel>();
            services.AddTransient<OrderDetailsViewModel>();
            services.AddTransient<MenuItemsDetailsViewModel>();
            services.AddTransient<MenuItemsViewModel>();
            services.AddTransient<TablesViewModel>();
            services.AddTransient<PlaceOrderViewModel>();
            services.AddTransient<LoginViewModel>();
            return services;
        }

    }

}
