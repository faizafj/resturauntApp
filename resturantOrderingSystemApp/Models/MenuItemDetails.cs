using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace resturantOrderingSystemApp.Models
{
    public class MenuItemsDetailsData
    {
        [JsonPropertyName("data")]
        public MenuItemDetails data { get; set; }
    }

    public class MenuItemDetails
    {
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("itemId")]
        public long orderId { get; set; }

        [JsonPropertyName("attributes")]
        public MenuItemDetailsAttributes attributes { get; set; }
    }

    public class MenuItemDetailsAttributes
    {
        [JsonPropertyName("itemName")]
        public string itemName { get; set; }

        [JsonPropertyName("itemPrice")]
        public string itemPrice { get; set; }

        [JsonPropertyName("itemDescription")]
        public string itemDescription { get; set; }

        [JsonPropertyName("category")]
        public string category { get; set; }

        [JsonPropertyName("allergies")]
        public string allergies { get; set; }

        [JsonPropertyName("nutritionalInfo")]
        public string nutritionalInfo { get; set; }

        [JsonPropertyName("itemPhoto")]
        public string itemPhoto { get; set; }
    }

}
