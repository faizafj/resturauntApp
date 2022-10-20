using resturantOrderingSystemApp.Navigation;
using Xamarin.Forms;
using resturantOrderingSystemApp.Views;
using resturantOrderingSystemApp.Interfaces;
using resturantOrderingSystemApp.Models;
using resturantOrderingSystemApp.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System;

namespace resturantOrderingSystemApp.ViewModels
{
    public class LoginViewModel : BaseViewModel

    {
        public Command  LoginCommand { get; set; }
        private readonly ILoginService _loginService;
        public string errorMessage = "";

        public LoginViewModel(ILoginService ApiLoginService) //command for navigation
        {
            LoginCommand = new Command(async () => await Login());
            _loginService = ApiLoginService;

        }

        public string username 
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(username));
            }
        }

        public string password 
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(password));
            }
        }

        private async Task Login() 
        {
            try
            {
                Console.WriteLine("Trying To Run Login Function");
                var loginDetails = new Account
                {
                    type = "Account",
                    attributes = new AccountAttributeData //attributes
                    {
                        username = username,
                        password = password,
 
                    }

                };

                var SuccessfullLogin = await _loginService.Login(loginDetails);
                if (SuccessfullLogin)
                {
                    Console.WriteLine("Success");
                    await Application.Current.MainPage.DisplayAlert("Login Success", "You have logged in successfully", "Ok");
                    NavigationDispatcher.Instance.Initialize(Application.Current.MainPage.Navigation);
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
