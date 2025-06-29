namespace AtlanticProductDesing.Application.Models.Checkout
{
    public class Order
    {
        public string Id { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Callback { get; set; } = string.Empty;
        public string ExternalId { get; set; } = string.Empty;
        public int ChargesCount { get; set; }
        public Charge Charge { get; set; }
    }
}
