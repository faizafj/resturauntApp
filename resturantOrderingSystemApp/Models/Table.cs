using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;

namespace resturantOrderingSystemApp.Models
{
    public class TablesData
    {
        [JsonPropertyName("data")]
        public List<Table> data { get; set; }
    }

    public class Table
    {
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("tableNumber")]
        public long tableNumber { get; set; }

        [JsonPropertyName("attributes")]
        public TableItemData attributes { get; set; }
    }

    public class TableItemData
    {
        [JsonPropertyName("tableStatus")]
        public string tableStatus { get; set; }

        [JsonPropertyName("tableSeats")]
        public long tableSeats { get; set; }
    }

}
