using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace resturantOrderingSystemApp.Models
{
    public class DetailsData
    {
        [JsonPropertyName("data")]
        public OrderDetails data { get; set; }
    }

    public class OrderDetails
    {
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("orderId")]
        public long orderId { get; set; }

        [JsonPropertyName("attributes")]
        public OrderDetailsData attributes { get; set; }
    }

    public class OrderDetailsData
    {
        [JsonPropertyName("orderStatus")]
        public string orderStatus { get; set; }

        [JsonPropertyName("orderTotal")]
        public string orderTotal { get; set; }

        [JsonPropertyName("tableNumber")]
        public long tableNumber { get; set; }

        [JsonPropertyName("user")]
        public string user { get; set; }

        [JsonPropertyName("timeOfOrder")]
        public string timeOfOrder { get; set; }

        [JsonPropertyName("date")]
        public string date { get; set; }

        [JsonPropertyName("numberOfPlaces")]
        public string numberOfPlaces { get; set; }

        [JsonPropertyName("items")]
        public List<orderItemList> items { get; set; }
    }

     public class orderItemList
    {
        [JsonPropertyName("itemId")]
        public long itemId { get; set; }

        [JsonPropertyName("attributes")]
        public orderItemDetails itemAttributes { get; set; }

    }

public class orderItemDetails
{
    [JsonPropertyName("itemName")]
    public string itemName { get; set; }

    [JsonPropertyName("itemPrice")]
    public string itemPrice { get; set; }

    [JsonPropertyName("itemDescription")]
    public string itemDescription { get; set; }

    [JsonPropertyName("allergies")]
    public string allergies { get; set; }

    [JsonPropertyName("nutritionalInfo")]
    public string nutritionalInfo { get; set; }

    [JsonPropertyName("itemPhoto")]
    public string itemPhoto { get; set; }

    [JsonPropertyName("quantity")]
    public long quantity { get; set; }
    }
}