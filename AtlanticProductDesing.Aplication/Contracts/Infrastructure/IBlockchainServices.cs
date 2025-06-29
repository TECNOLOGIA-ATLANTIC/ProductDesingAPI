
using AtlanticProductDesing.Application.DTOs;
using AtlanticProductDesing.Application.Models;

namespace AtlanticProductDesing.Application.Contracts.Infrastructure
{
    public interface IBlockchainServices
    {
        Task<Wallet> CreateWallet(WalletRequestDto data);
        Task<Wallet> GetWallet(string walletId);
        Task<Token> CreateToken(TokenRequestDto data);
        Task<Token> GetToken(string tokenId);
        Task<WalletToken> AddTokenToWallet(WalletTokenRequestDto data, string walletId);
        Task<BaseApiResponse> TokenTransfer(Transfer data);
        Task<BaseApiResponse> GetTransfer(string transferId);
        Task<Double> GetTokenToWallet(string walletId, string tokenId);
        Task<string> DeleteTokenToWallet(string walletId, BurnsTokenDto data);
        Task<Stats> GetStast();

    }
}
