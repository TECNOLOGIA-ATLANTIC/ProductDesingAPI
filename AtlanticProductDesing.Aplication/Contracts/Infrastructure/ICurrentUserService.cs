namespace AtlanticProductDesing.Application.Contracts.Infrastructure
{
    public interface ICurrentUserService
    {
        string GetUserName();
        string? GetEmailUser();
        IEnumerable<string>? GetUserRole();
    }
}
