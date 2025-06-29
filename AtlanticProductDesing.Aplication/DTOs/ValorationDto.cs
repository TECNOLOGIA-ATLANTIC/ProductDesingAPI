namespace AtlanticProductDesing.Application.DTOs
{
    public class ValorationDto
    {
        public int Id { get; set; }
        public double QuantityToken { get; set; } // Quantity Token 
        public double AmountUSDD { get; set; } // Total Amount (Balance available) in USDD
        public double AmountToken { get; set; } // Amount per token in USDD
        public double QuantityTokenWithhold { get; set; } // Quantity tokens retained
        public double QuantityTokenAvailable { get; set; } // Quantity token available
        public double TotalQuantityToken { get; set; } // total quantity acumulated token
        public double TotalAmount { get; set; }// total valoration project
        public double TotalValorationUSDD { get; set; } // Total Amount (Valoration total) in USDD
        public int ProjectId { get; set; }
        public string Status { get; set; } // 0: inactivo
        public bool ServiceFailed { get; set; }// If blockchain services fail
    }
}
