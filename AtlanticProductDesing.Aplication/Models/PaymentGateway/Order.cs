namespace AtlanticProductDesing.Application.Models.PaymentGateway
{
    public class Order
    {
        public string UserId { get; set; }
        public string StoreId { get; set; }
        public string OrderId { get; set; }
        public string StoreShortName { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
