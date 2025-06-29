namespace AtlanticProductDesing.Application.DTOs
{
    public class CashInCreditCardRequestDTO
    {
        public string Number { get; set; }
        public string SecurityCode { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
        public double Amount { get; set; }
        public decimal AmountToPay { get; set; }
    }
}
