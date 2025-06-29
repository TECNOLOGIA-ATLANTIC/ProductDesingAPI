namespace AtlanticProductDesing.Application.Models.Checkout
{
    public class ListTransactions
    {
        public int Page { get; set; }
        public int Pages { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public List<Transaction>? Transactions { get; set; }
    }
}

