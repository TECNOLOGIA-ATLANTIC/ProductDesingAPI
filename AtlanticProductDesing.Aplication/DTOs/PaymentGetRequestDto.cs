namespace AtlanticProductDesing.Application.DTOs
{
    public class PaymentGetRequestDto
    {
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;
        public string MerchantId { get; set; } = string.Empty;
        public string Page { get; set; } = string.Empty;
        public string Limit { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
