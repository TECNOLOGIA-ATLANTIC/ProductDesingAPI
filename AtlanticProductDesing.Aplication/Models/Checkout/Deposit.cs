namespace AtlanticProductDesing.Application.Models.Checkout
{
    /// <summary>
    /// Solo para simular el deposito realizado en crypto
    /// </summary>
    public class Deposit
    {
        public double Amount { get; set; }
        public string AddressId { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
    }
}
