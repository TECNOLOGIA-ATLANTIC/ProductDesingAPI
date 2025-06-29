using AtlanticProductDesing.Application.Models.PaymentGateway;

namespace AtlanticProductDesing.Application.Contracts.Infrastructure
{
    public interface IPaymentGatewayService
    {
        Task<PaymentTransaction> ToPay(Payment PayData);
    }
}
