using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using resturantOrderingSystemApp.Models;
using resturantOrderingSystemApp.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Essentials;

namespace resturantOrderingSystemApp.Services
{
    public class ApiLoginService : ILoginService
    {
        private readonly HttpClient _httpClient;
        public ApiLoginService()
        {
#if DEBUG
            HttpClientHandler insecureHandler = GetInsecureHandler();
            _httpClient = new HttpClient(insecureHandler);
#else

            HttpClient _httpClient = new HttpClient();
#endif
            _httpClient.BaseAddress = new Uri("https://limbo-forever-8080.codio-box.uk/api/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.api+json");
        }

        public async Task<bool> Login(Account accountDetails)
        {
            try
            {
                Console.WriteLine("Trying To Run Login API");
                var authenticationDataString = string.Format( "{0}:{1}", accountDetails.attributes.username, accountDetails.attributes.password);
                var encodedData = Convert.ToBase64String(Encoding.UTF8.GetBytes(authenticationDataString));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedData);
                var response = await _httpClient.GetAsync("accounts");

                if (response.IsSuccessStatusCode)
                {
                    var responseAsString = await response?.Content?.ReadAsStringAsync();
                    Console.WriteLine(responseAsString);
                    var tr = JsonSerializer.Deserialize<Account>(responseAsString);
                    await SecureStorage.SetAsync("username", tr.attributes.username);
                    await SecureStorage.SetAsync("userType", tr.attributes.userType);
                    Console.WriteLine(tr.attributes.username);
                    Console.WriteLine(tr.attributes.userType);
                    return true; 

                }

            }
            catch (Exception e)
            {
                Debug.Fail(e.Message);
            }
            return false;
        }


        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
    }
}

