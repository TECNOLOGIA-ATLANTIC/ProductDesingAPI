﻿namespace AtlanticProductDesing.Application.Models
{
    public class EmailSettings
    {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public bool ReplaceTo { get; set; }
    }
}
