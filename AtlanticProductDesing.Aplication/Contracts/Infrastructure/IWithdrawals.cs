using AtlanticProductDesing.Application.Models.Withdrawals;


namespace AtlanticProductDesing.Application.Contracts.Infrastructure
{
    public interface IWithdrawalsService
    {
        Task<bool> CreateWithdrawal(WithdrawalR withdrawal);
        Task<bool> CreateWithdrawalMaster(WithdrawalMaster withdrawal);
    }
}
