using AtlanticProductDesing.Application.Models;

namespace AtlanticProductDesing.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
