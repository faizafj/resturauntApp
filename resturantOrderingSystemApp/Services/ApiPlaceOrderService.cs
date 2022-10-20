using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;
using resturantOrderingSystemApp.Models;
using resturantOrderingSystemApp.Interfaces;
using System.Net.Http.Headers;
using Xamarin.Essentials;

namespace resturantOrderingSystemApp.Services
{
    public class ApiPlaceOrderService : IPlaceOrderService
    {
        private readonly HttpClient _httpClient;
        public ApiPlaceOrderService()
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

        public async Task<bool> PlaceOrder (PlaceOrder placedOrder) //view all orders
        {
            HttpResponseMessage response = new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "RmFpemFKYXZlZDpwNDU1dzByZA ==");
                response = await _httpClient.PostAsync("v1/orders",
                             new StringContent(JsonSerializer.Serialize(placedOrder), Encoding.UTF8, "application/vnd.api+json"));

            }
            catch (Exception e)
            {
                Debug.Fail(e.Message);
            }
            return response.IsSuccessStatusCode;
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

