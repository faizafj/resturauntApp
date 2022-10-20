using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using resturantOrderingSystemApp.ViewModels;
using Xamarin.Forms;

namespace resturantOrderingSystemApp.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = Startup.ServiceProvider.GetService<LoginViewModel>();
        }
    }
}
