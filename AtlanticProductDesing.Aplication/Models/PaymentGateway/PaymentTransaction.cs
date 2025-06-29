namespace AtlanticProductDesing.Application.Models.PaymentGateway
{
    public class PaymentTransaction
    {
        public long Id { get; set; }
        public long IdPaymentGateway { get; set; }
        public string SiteTransactionId { get; set; }
        public int PaymentMethodId { get; set; }
        public string CardBrand { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Status { get; set; }
        public string Ticket { get; set; }
        public string CardAuthorizationCode { get; set; }
        public string AddressValidationCode { get; set; }
        public string Error { get; set; }
        public string Date { get; set; } = string.Empty;
        public string CustomerId { get; set; }
        public string Bin { get; set; }
        public string PaymentType { get; set; }
        public string CustomerToken { get; set; }
        public string Token { get; set; }
        public string CardData { get; set; }
        public string FraudDetection { get; set; }
    }
}
