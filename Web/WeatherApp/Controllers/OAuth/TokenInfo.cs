﻿using Sequencing.WeatherApp.Models;

namespace Sequencing.WeatherApp.Controllers.OAuth
{
    /// <summary>
    /// OAuth token data
    /// </summary>
    public class TokenInfo
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public string refresh_token { get; set; }
        public AuthAppType? appType { get; set; }
    }
}