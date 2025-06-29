using AtlanticProductDesing.Application.DTOs;
using AtlanticProductDesing.Application.Models.Checkout;

namespace AtlanticProductDesing.Application.Contracts.Infrastructure
{
    public interface ICheckoutServices
    {
        Task<Order> CreateOrder(OrderRequestDto request);
        Task<Order> GetOrder(string OrderId);
        Task<IEnumerable<Coin>> GetCoins();
        Task<ExchangeRate> GetRate(string currencyCode);
        Task<ListTransactions> GetTransactions(string page, string limit);
        Task<Transaction> GetTransaction(string IdTransactionDecidir);
        Task<string> MockPayOrder(Deposit deposit);
    }
}
