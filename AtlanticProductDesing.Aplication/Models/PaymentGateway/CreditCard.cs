namespace AtlanticProductDesing.Application.Models.PaymentGateway
{
    public class CreditCard
    {
        public string Number { get; set; } = string.Empty;
        public string SecurityCode { get; set; } = string.Empty;
        public string ExpirationMonth { get; set; } = string.Empty;
        public string ExpirationYear { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
    }
}
