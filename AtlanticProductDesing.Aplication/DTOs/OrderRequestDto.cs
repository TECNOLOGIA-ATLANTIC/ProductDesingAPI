namespace AtlanticProductDesing.Application.DTOs
{
    public class OrderRequestDto
    {
        public int Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Callback { get; set; } = string.Empty;
        public string ExternalId { get; set; } = string.Empty;
    }
}
