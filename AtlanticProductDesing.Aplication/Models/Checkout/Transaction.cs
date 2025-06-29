namespace AtlanticProductDesing.Application.Models.Checkout
{
    public class Transaction
    {
        public string Id { get; set; } = string.Empty;
        public string IdDecidir { get; set; } = string.Empty;
        public string Amount { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Network { get; set; } = string.Empty;
        public string ExternalId { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public string BaseCallback { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string UpdatedAt { get; set; } = string.Empty;
    }
}

