namespace AtlanticProductDesing.Application.DTOs
{
    public class WalletTokenDto
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string TransactionStatus { get; set; }
        public string Type { get; set; } = string.Empty;
        public string TokenId { get; set; }
        public TokenDto Token { get; set; }
        public double QuantityToken { get; set; } // Quantity Token 
        public double AmountUSDD { get; set; } // Total Amount (Balance) in USDD
        public double AmountToken { get; set; } // Amount per token in USDD
        public double QuantityTokenWithhold { get; set; } // Quantity tokens retained
        public double QuantityTokenAvailable { get; set; } // Quantity token available
        public double TotalQuantityToken { get; set; } // total quantity acumulated token
        public double TotalAmount { get; set; }// total valoration project
        public bool ServiceFailed { get; set; }// If blockchain services fail
    }
}
