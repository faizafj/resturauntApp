using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace resturantOrderingSystemApp.Models
{
    public class PlacedOrderData
    {
        [JsonPropertyName("data")]
        public List<PlaceOrder> data { get; set; }
    }

    public class PlaceOrder
    {
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("attributes")]
        public PlaceOrderData attributes { get; set; }
    }

    public class PlaceOrderData

    {
        [JsonPropertyName("orderId")]
        public string orderId { get; set; } //orderId + 1

        [JsonPropertyName("orderStatus")] //set to placed
        public string orderStatus { get; set; }

        [JsonPropertyName("orderTotal")] 
        public string orderTotal { get; set; }

        [JsonPropertyName("user")]
        public string user { get; set; }

        [JsonPropertyName("timeOfOrder")]
        public string timeOfOrder { get; set; }

        [JsonPropertyName("itemId")]
        public string itemId { get; set; }

        [JsonPropertyName("quantity")]
        public long quantity { get; set; }

        [JsonPropertyName("date")]
        public string date { get; set; }

        [JsonPropertyName("numberOfPlaces")]
        public long numberOfPlaces { get; set; }
    }

}
