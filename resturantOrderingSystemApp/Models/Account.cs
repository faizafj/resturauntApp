using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace resturantOrderingSystemApp.Models
{
    public class AccountData
    {
        [JsonPropertyName("data")]
        public List<Account> data { get; set; }
    }

    public class Account
    {
        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("attributes")]
        public AccountAttributeData attributes { get; set; }
    }

    public class AccountAttributeData
    {
        [JsonPropertyName("username")]
        public string username { get; set; }

        [JsonPropertyName("password")]
        public string password { get; set; }


        [JsonPropertyName("userType")]
        public string userType { get; set; }

    }
}
