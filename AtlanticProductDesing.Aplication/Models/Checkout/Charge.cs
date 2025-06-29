namespace AtlanticProductDesing.Application.Models.Checkout
{
    public class Charge
    {
        public string Id { get; set; }
        public int LocalAmount { get; set; }
        public string AmountUsd { get; set; } = string.Empty;
        public string AmountCurrency { get; set; } = string.Empty;
        public int FixedAmount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string Network { get; set; } = string.Empty;
        public string LocalCurrency { get; set; } = string.Empty;
        public string InternalCurrencyCode { get; set; } = string.Empty;
        public string PivotCurrency { get; set; } = string.Empty;
        public string Rate { get; set; } = string.Empty;
        public string Fee { get; set; } = string.Empty;
        public string ExpiresAt { get; set; } = string.Empty;
        public double Ttl { get; set; }
        public string TtlThreshold { get; set; } = string.Empty;
        public string OverpaidThreshold { get; set; } = string.Empty;
        public string UnderpaidThreshold { get; set; } = string.Empty;
        public string Order { get; set; } = string.Empty;
        public Address Address { get; set; }
    }
}
