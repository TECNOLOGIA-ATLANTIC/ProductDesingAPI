
using AtlanticProductDesing.Application.Contracts.Infrastructure;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace AtlanticProductDesing.Infrastruture.CurentUser
{
    public class CurrentUserApiService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserApiService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string? GetEmailUser()
        {
            var email = _contextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;
            return !string.IsNullOrEmpty(email) ? email : "";
        }

        public string GetUserName()
        {
            var userName = _contextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.Email)?.Value;

            return !string.IsNullOrEmpty(userName) ? userName : "System";
        }

        public IEnumerable<string>? GetUserRole()
        {
            var roleClaims = _contextAccessor?.HttpContext?.User?.FindAll(ClaimTypes.Role).ToList();
            return roleClaims?.Select(role => role.Value);
        }
    }
}
