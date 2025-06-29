namespace AtlanticProductDesing.Application.DTOs
{
    public class PaymentPostRequestDto
    {
        public string Token { get; set; } = string.Empty;
        public int PaymentMethod { get; set; }
        public string Bin { get; set; } = string.Empty;
        public int Amount { get; set; }
        public int Installments { get; set; }
        public string Callback { get; set; } = string.Empty;
        public string Merchant_id { get; set; } = string.Empty;
        public MetaDataDto MetaData { get; set; }
    }
}
