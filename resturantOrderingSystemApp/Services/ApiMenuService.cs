using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using resturantOrderingSystemApp.Models;
using resturantOrderingSystemApp.Interfaces;
using System.Net.Http.Headers;
using Xamarin.Essentials;

namespace resturantOrderingSystemApp.Services
{
    public class ApiMenuService : IMenuService
    {
        private readonly HttpClient _httpClient;
        public ApiMenuService()
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

        public async Task<IEnumerable<MenuItem>> GetMenuItems() //view all MenuItems
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "RmFpemFKYXZlZDpwNDU1dzByZA ==");
                var response = await _httpClient.GetAsync("v1/menuItems");

                if (response.IsSuccessStatusCode)
                {
                    var responseAsString = await response?.Content?.ReadAsStringAsync();
                    Console.WriteLine(responseAsString);
                    var tr = JsonSerializer.Deserialize<MenuItemsData>(responseAsString);
                    Console.WriteLine(tr.data);
                    return tr.data;

                }

            }
            catch (Exception e)
            {
                Debug.Fail(e.Message);
            }
            return new List<MenuItem>();
        }


        public async Task<MenuItemDetails> GetMenuItemDetails(long itemId) //view details for a specific Order
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "RmFpemFKYXZlZDpwNDU1dzByZA ==");
                var response = await _httpClient.GetAsync("v1/menuItems/" + itemId);

                if (response.IsSuccessStatusCode)
                {
                    var responseAsString = await response?.Content?.ReadAsStringAsync();
                    Console.WriteLine(responseAsString);
                    var tr = JsonSerializer.Deserialize<MenuItemsDetailsData>(responseAsString);
                    Console.WriteLine(tr.data);
                    return tr.data;

                }

            }
            catch (Exception e)
            {
                Debug.Fail(e.Message);
            }
            return null;
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

