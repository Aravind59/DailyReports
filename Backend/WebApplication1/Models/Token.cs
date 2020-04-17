using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DailyReports.Contracts.Models;
using Newtonsoft.Json;

namespace DailyReports.Models
{
    internal class Token
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        public UserDetails User { get; set; }
    }
}