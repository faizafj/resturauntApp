using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace resturantOrderingSystemApp.Models
{
    public class Data
    {
        [JsonPropertyName("data")]
        public List <Order> data { get; set; }
    }

    public class Order
    {
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("orderId")]
        public long orderId { get; set; }

        [JsonPropertyName("attributes")]
        public OrderData attributes { get; set; }
    }

    public class OrderData
    {
        [JsonPropertyName("orderStatus")]
        public string orderStatus { get; set; }

        [JsonPropertyName("orderTotal")]
        public string orderTotal { get; set; }

        [JsonPropertyName("user")]
        public string user { get; set; }

        [JsonPropertyName("timeOfOrder")]
        public string timeOfOrder { get; set; }

        [JsonPropertyName("items")]
        public List <itemDetails> items { get; set; }

        [JsonPropertyName("date")]
        public string date { get; set; }

        [JsonPropertyName("quantity")]
        public long quantity { get; set; }

        [JsonPropertyName("numberOfPlaces")]
        public string  numberOfPlaces { get; set; }
    }

    public class itemDetails
    {
        [JsonPropertyName("itemId")]
        public long itemId { get; set; }
        [JsonPropertyName("itemName")]
        public string itemName { get; set; }
        [JsonPropertyName("quantity")]
        public long quantity { get; set; }

    }

}
