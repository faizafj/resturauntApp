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
    public class ApiTableService : ITableService
    {
        private readonly HttpClient _httpClient;
        public ApiTableService()
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

        public async Task<IEnumerable<Table>> GetAvailableTables() //view Tables
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", "RmFpemFKYXZlZDpwNDU1dzByZA ==");
                var response = await _httpClient.GetAsync("v1/availableTables");

                if (response.IsSuccessStatusCode)
                {
                    var responseAsString = await response?.Content?.ReadAsStringAsync();
                    Console.WriteLine(responseAsString);
                    var tr = JsonSerializer.Deserialize<TablesData>(responseAsString);
                    Console.WriteLine(tr.data);
                    return tr.data;
                }

            }
            catch (Exception e)
            {
                Debug.Fail(e.Message);
            }
            return new List<Table>();
        }


        public async Task<bool> UpdateTable(Table TableToUpdate) //update status for order
        {
            HttpResponseMessage response = new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                var AuthKey = await SecureStorage.GetAsync("AuthKey");
                string[] AuthenticationElements = AuthKey.Split(' ');
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationElements[0], AuthenticationElements[1]);
                response = await _httpClient.PutAsync($"v3/availableTables/{TableToUpdate.tableNumber}",
                    new StringContent(JsonSerializer.Serialize(TableToUpdate), Encoding.UTF8, "application/vnd.api+json"));
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

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

