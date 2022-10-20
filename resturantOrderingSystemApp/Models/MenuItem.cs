using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace resturantOrderingSystemApp.Models
{
    public class MenuItemsData
    {
        [JsonPropertyName("data")]
        public List <MenuItem> data { get; set; }
    }

    public class MenuItem
    {
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("itemId")]
        public long itemId { get; set; }

        [JsonPropertyName("attributes")]
        public MenuItemData attributes { get; set; }
    }

    public class MenuItemData
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

        [JsonPropertyName("itemPhoto")]
        public string itemPhoto { get; set; }
    }

}
