using AtlanticProductDesing.Application.Models.Identity;
using AtlanticProductDesing.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

//using Microsoft.AspNetCore.Identity;
namespace AtlanticProductDesing.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<AuthResponse> Login(AuthSocialRequest request);


        Task<UserResponse> ConfirmEmail(ConfirmEmailRequest request);

        Task<RecoverPasswordResponse> RecoverPassword(RecoverPasswordRequest request);
        Task ChangePassword(ChangePasswordRequest request);

        Task<IEnumerable<UserList>> Users(string? userType, string? order, string? search);

        Task<IEnumerable<UserList>> UsersInactive(int? top);

        Task<UserResponse> GetUser(string id);
        Task<UserResponse?> GetUserByUserName(string userName);
        Task UpdateRegister(RegistrationUpdateRequest request);

        Task UpdateProfileRegister(RegistrationProfileUpdateRequest request);

        Task ActivateUser(ActivationUserRequest request);
        AuthenticationProperties GoogleLogin(string? redirectUrl);

        Task<ExternalLoginInfo> GetExternalLoginInfo();
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool v);
        Task<string> Register(IUserRegisterData request, string[] roles);
        Task<UserResponse> Register(RegistrationSocialRequest request);
        Task<UserResponse> Register(RegistrationFacebookRequest request);
        Task<Boolean> IsAuthorize(AuthRequest request);
        Task<AuthResponse> RefreshToken(CheckTokenRequest request);
        Task LogOff();
        Task UpdatePassword(string id, string actualPassword, string newPassword);
    }
}
