using AtlanticProductClient.Application.Constants;
using AtlanticProductClient.Application.Contracts.Identity;
using AtlanticProductClient.Application.Contracts.Infrastructure;
using AtlanticProductClient.Application.Exceptions;
using AtlanticProductClient.Application.Models;
using AtlanticProductClient.Application.Models.Identity;
using AtlanticProductClient.Domain.Interfaces;
using AtlanticProductClient.Identity.Models;
using AtlanticProductClient.Identity.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLog;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AtlanticProductClient.Identity.Services
{
    /// <summary>
    /// clase para manejar los usuarios y la autenticación
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IEmailService _emailservice;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private readonly IConfiguration _configuration;
        private readonly IDataProtector _protector;
        private readonly IdentityDbContext _context;
        private readonly IFileSystemService _fileSystemService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<JwtSettings> jwtSettings,
            IEmailService emailservice,
            IConfiguration configuration,
            IDataProtectionProvider protector,
            IFileSystemService fileSystemService,
            IdentityDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _emailservice = emailservice;
            _configuration = configuration;
            _protector = protector.CreateProtector("AuthService.protector");
            _fileSystemService = fileSystemService;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                string message = string.Format("El usuario con el email {0} no existe.", request.Email);
                throw new UnauthorizedAccessException(message);

            }

            if (!user.EmailConfirmed)
            {
                string message = string.Format("El correo {0}, aun no ha sido confirmado.", request.Email);
                throw new UnauthorizedAccessException(message);

            }


            //if (!user.Verified && (!string.IsNullOrEmpty(user.DocumentFrontImage) && !string.IsNullOrEmpty(user.DocumentBackImage)))
            //{
            //    string message = string.Format("Su cuenta aun no ha sido verificada.");
            //    throw new UnauthorizedAccessException(message);

            //}


            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                if (result.IsNotAllowed)
                {
                    string message = string.Format("Acceso no permitido.");
                    throw new UnauthorizedAccessException(message);
                }
                else
                {
                    string message = string.Format("Las credendicales son incorrectas.");
                    throw new UnauthorizedAccessException(message);
                }
            }


            var token = await GenerateToken(user);

            var roles = await _userManager.GetRolesAsync(user);

            //var refreshToken = await GenerateToken(user);

            var auhtResponse = new AuthResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresIn = (int)_jwtSettings.DurationInMinutes * 60,
                User = MapAuthUser(user, roles)

            };

            return auhtResponse;
        }

        private AuthUser MapAuthUser(ApplicationUser user, IList<string> roles)
        {
            return new AuthUser()
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                Verified = user.Verified,
                EmailConfirmed = user.EmailConfirmed,
                // IdDocumentImageLoaded = !string.IsNullOrWhiteSpace(user.UrlDocumentId),
                Roles = roles,
            };
        }

        public async Task LogOff()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task UpdatePassword(string id, string actualPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.ChangePasswordAsync(user, actualPassword, newPassword);

            if (result.Errors.Any())
            {
                var errors = new ValidationException();

                foreach (var item in result.Errors)
                {
                    errors.Errors.Add("error", result.Errors.Select(x => x.Description).ToArray());
                }

                throw errors;
            }
        }

        /// <summary>
        /// Login para las redes sociales
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AuthResponse> Login(AuthSocialRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                string message = string.Format("El usuario con el email {0} no existe.", request.Email);
                throw new BadRequestException(message);

            }
            if (!user.EmailConfirmed)
            {
                string message = string.Format("El correo {0}, aun no ha sido confirmado.", request.Email);
                throw new BadRequestException(message);
            }


            //if (!user.Verified && (!string.IsNullOrEmpty(user.DocumentFrontImage) && !string.IsNullOrEmpty(user.DocumentBackImage)))
            //{
            //    string message = string.Format("Su cuenta aun no ha sido verificada.");
            //    throw new BadRequestException(message);
            //}


            await _signInManager.SignInAsync(user, false);

            var token = await GenerateToken(user);

            var roles = await _userManager.GetRolesAsync(user);

            var refreshToken = GenerateRefreshToken();

            var auhtResponse = new AuthResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                //RefreshToken = refreshToken,
                ExpiresIn = (int)_jwtSettings.DurationInMinutes,
                User = MapAuthUser(user, roles)
            };

            // Save the refresh token in the database or any persistent storage
            ////await SaveRefreshToken(user, refreshToken);

            return auhtResponse;
        }


        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        //private async Task SaveRefreshToken(ApplicationUser user, string refreshToken)
        //{
        //    user.RefreshToken = refreshToken;
        //    user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7); // Set the refresh token expiry time
        //    await _userManager.UpdateAsync(user);
        //}


        /// <summary>
        /// Login para las redes sociales
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<AuthResponse> RefreshToken(CheckTokenRequest request)
        {
            string nameIdentifier = ClaimTypes.NameIdentifier;
            string name = null;
            try
            {
                name = _httpContextAccessor.HttpContext.User.FindFirst(nameIdentifier).Value;
            }
            catch (Exception ex)
            {
                _logger.Error("No se pudo refrescar el token. Error: {0}.", ex.Message);
                _logger.Trace("No se pudo refrescar el token. Trace: {0}.", ex.StackTrace);
                string message = string.Format("Usuario no logueado.");
                throw new UnauthorizedAccessException(message);
            }
            ApplicationUser user = await _userManager.FindByNameAsync(name);

            if (user == null)
            {
                string message = string.Format("Usuario no logueado.");
                throw new UnauthorizedAccessException(message);

            }
            if (!user.EmailConfirmed)
            {
                string message = string.Format("El correo del usuario {0}, aun no ha sido confirmado.", user.Name);
                throw new UnauthorizedAccessException(message);
            }


            //if (!user.Verified && (!string.IsNullOrEmpty(user.DocumentFrontImage) && !string.IsNullOrEmpty(user.DocumentBackImage)))
            //{
            //    string message = string.Format("Su cuenta aun no ha sido verificada.");
            //    throw new UnauthorizedAccessException(message);
            //}


            await _signInManager.SignInAsync(user, false);

            var token = await GenerateToken(user);

            var roles = await _userManager.GetRolesAsync(user);

            var auhtResponse = new AuthResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                User = MapAuthUser(user, roles)
            };

            return auhtResponse;
        }

        /// <summary>
        /// metodos para recuperar la contraseña 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        public async Task<RecoverPasswordResponse> RecoverPassword(RecoverPasswordRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email);

            _logger.Info("Recuperación password: {0}.", request.Email);

            if (existingUser == null)
            {
                _logger.Error("El usuario no existe: {0}.", request.Email);
                throw new NotFoundException(nameof(existingUser), request.Email);
            }

            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(existingUser);

            await SendRecoverPassword(existingUser, resetToken);

            return new RecoverPasswordResponse
            {
                Email = existingUser.Email,
                Message = "Enviamos un correo electrónico con las instrucciones para cambiar su contraseña."
            };

        }

        /// <summary>
        /// Send recover password email
        /// </summary>
        /// <param name="user"></param>
        /// <param name="resetToken"></param>
        /// <returns></returns>
        private async Task SendRecoverPassword(ApplicationUser user, string resetToken)
        {
            List<EmailAttachment> listAttachment = new List<EmailAttachment>();

            listAttachment.Add(new EmailAttachment
            {
                FilePath = Directory.GetCurrentDirectory() + @"\Assets\Image\BodyImageEmail\logo.png",
                Type = "image/png",
                ContentId = "logo",
                Disposition = "inline",
                FileName = "logo.png"
            });

            var email = new Email
            {
                To = user.Email,
                Body = await BuildBodyRecoverPassword(user.Email, resetToken),
                Subject = "AtlanticProductClient - Recuperación de contraseña.",
                emailAttachments = listAttachment
            };

            try
            {
                await _emailservice.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.Error("Errores enviando el email de recuperación de contraseña: {0}.", user.Email);
            }

        }

        /// <summary>
        /// Send recover password email
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task SendActivedUserEmail(ApplicationUser user)
        {
            List<EmailAttachment> listAttachment = new();

            listAttachment.Add(new EmailAttachment
            {
                FilePath = Directory.GetCurrentDirectory() + @"\Assets\Image\BodyImageEmail\logo.png",
                Type = "image/png",
                ContentId = "logo",
                Disposition = "inline",
                FileName = "logo.png"
            });

            Email email = new()
            {
                To = user.Email,
                Body = await BuidlBodyActiviedUserEmail(user),
                Subject = "DONC - Usuario Activado.",
                emailAttachments = listAttachment
            };

            try
            {
                await _emailservice.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.Error("Errores enviando el email de Usuario Activo: {0}.", user.Email);
                _logger.Error("Errores enviando el email de Usuario Activo. Message: {0}.", ex.Message);
                _logger.Trace("Errores enviando el email de Usuario Activo. Trace: {0}.", ex.StackTrace);
            }

        }

        /// <summary>
        /// Register account new user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        /// <exception cref="ConflictException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<UserResponse> Register(RegistrationRequest request)
        {
            if (!request.AcceptPolicies)
            {
                _logger.Error("No ha aceptado las políticas {0}", request.Email);
                throw new BadRequestException("Debe aceptar las políticas.");
            }

            ApplicationUser existingUser = await _userManager.FindByEmailAsync(request.Email);
            _logger.Info("Registro del usuario {0}", request.Email);

            if (existingUser != null)
            {
                _logger.Error("Registro de usuario {0} Fallo. Usuario ya existe.", request.Email);
                throw new ConflictException("El usuario ya existe.");
            }

            ApplicationUser user = new ApplicationUser
            {
                Email = request.Email,
                Name = request.Name,
                LastName = request.LastName,
                UserName = request.Email,
                EmailConfirmed = false,
                //  CreateDate = DateTime.UtcNow
            };

            IdentityResult createUser = await _userManager.CreateAsync(user, request.Password);

            _logger.Info("Usuario registrado {0}.", request.Email);

            if (!createUser.Succeeded)
            {
                throw new Exception($"{createUser.Errors}");
            }

            await _userManager.AddToRoleAsync(user, "Investor");

            string? token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            await SendConfirmEmail(user, token);
            UserResponse userResponse = _context.Users.Select(x =>
            new UserResponse
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.Name,
                LastName = x.LastName,
                EmailConfirmed = x.EmailConfirmed,
                Verified = x.Verified,
                //isDocumentsUpload = x.UrlDocumentId != null && x.UrlDocumentIdBack != null
            }).First(x => x.Email == user.Email);

            return userResponse;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<UserResponse> Register(RegistrationFacebookRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.email))
            {
                _logger.Error("Account de facebook sin correo");
                throw new ConflictException("Su cuenta de facebook debe tener asociada un email para poder validar su usuario.");
            }

            ApplicationUser existingUser = await _userManager.FindByEmailAsync(request.email);
            _logger.Info("Usuario registrado mediante facebook {0}", request.email);

            if (existingUser != null)
            {
                string message = string.Format("El usuario ya existe: {0}", request.email);
                _logger.Error("Registro de usuario fallido. " + message);
                throw new ConflictException(message);
            }

            ApplicationUser user = new ApplicationUser
            {
                Email = request.email,
                Name = request.name,
                LastName = request.lastName,
                UserName = request.email,
                EmailConfirmed = false,
                // CreateDate = DateTime.Now

            };

            IdentityResult createUser = await _userManager.CreateAsync(user, $"{request.email}#{request.id}");

            _logger.Error("Usuario Registrado {0}.", request.email);

            if (!createUser.Succeeded)
            {
                string message = string.Format("{0}", createUser.Errors);
                _logger.Error("Registro de usuario fallido. " + message);
                throw new Exception(message);
            }

            await _userManager.AddToRoleAsync(user, "Investor");

            string? token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            await SendConfirmEmail(user, token);
            UserResponse userResponse = _context.Users.Select(x =>
            new UserResponse
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.Name,
                LastName = x.LastName,
                EmailConfirmed = x.EmailConfirmed,
                Verified = x.Verified,
                //isDocumentsUpload = x.UrlDocumentId != null && x.UrlDocumentIdBack != null
            }).First(x => x.Email == user.Email);

            return userResponse;

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<UserResponse> Register(RegistrationSocialRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.email))
            {
                _logger.Error("Account sin email: {0}.", request.provider);
                throw new ConflictException("Su cuenta de gmail debe tener asociada un email para poder validar su usuario.");
            }

            ApplicationUser existingUser = await _userManager.FindByEmailAsync(request.email);
            _logger.Info("Registro de usuario {0}", request.email);

            if (existingUser != null)
            {
                _logger.Error("Registro de usuario fallido {0}. El usuario ya existe.", request.email);
                throw new ConflictException("El usuario ya existe.");
            }


            ApplicationUser user = new ApplicationUser
            {
                Email = request.email,
                Name = request.name,
                LastName = request.lastName,
                UserName = request.email,
                EmailConfirmed = false,
                // CreateDate = DateTime.Now

            };
            IdentityResult identResult = await _userManager.CreateAsync(user);

            if (identResult.Succeeded)
            {

                UserLoginInfo userInfo = new UserLoginInfo(request.provider, request.id, request.provider);

                identResult = await _userManager.AddLoginAsync(user, userInfo);
                if (identResult.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                }
                else
                {
                    throw new Exception(string.Format("{0}.", identResult.Errors));
                }
            }

            _logger.Info("Usuario registrado con Google {0}.", request.email);

            await _userManager.AddToRoleAsync(user, "Investor");

            string? token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            await SendConfirmEmail(user, token);
            UserResponse userResponse = _context.Users.Select(x =>
            new UserResponse
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.Name,
                LastName = x.LastName,
                EmailConfirmed = x.EmailConfirmed,
                Verified = x.Verified,
                //isDocumentsUpload = x.UrlDocumentId != null && x.UrlDocumentIdBack != null
            }).First(x => x.Email == user.Email);

            return userResponse;
        }

        /// <summary>
        /// method to recover password to user
        /// </summary>
        /// <param name="request">date change password</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="BadRequestException"></exception>
        public async Task ChangePassword(ChangePasswordRequest request)
        {

            string req = _protector.Unprotect(request.Key);
            string email = req.Split(this._configuration.GetSection("AccountSettings").GetSection("WordSplit").Value)[0];
            string token = req.Split(this._configuration.GetSection("AccountSettings").GetSection("WordSplit").Value)[1];


            ApplicationUser existingUser = await _userManager.FindByEmailAsync(email);
            _logger.Info("Confirmación de correo {0}.", email);

            if (existingUser == null)
            {
                _logger.Error("Correo no encontrado {0}.", email);
                throw new NotFoundException("Correo no encontrado.", email);
            }


            _logger.Info("Cambio de contraseña: {0}.", email);

            if (existingUser == null)
            {
                string message = string.Format("El usuario no existe: {0}.", email);
                _logger.Error(message);
                throw new Exception(message);
            }

            IdentityResult result = await _userManager.ResetPasswordAsync(existingUser, token, request.Password);

            if (result.Errors.Any())
            {
                _logger.Error("No se pudo realizar el cambio de contraseña: {0}.", email);
                throw new BadRequestException("No se puedo cambiar la contraseña.");
            }
            _logger.Info("Cambio de contraseña ha sido exitoso: {0}.", email);

        }

        /// <summary>
        /// /method to confrim email to user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<UserResponse> ConfirmEmail(ConfirmEmailRequest request)
        {
            string req = _protector.Unprotect(request.key);
            string email = req.Split(this._configuration.GetSection("AccountSettings").GetSection("WordSplit").Value)[0];
            string token = req.Split(this._configuration.GetSection("AccountSettings").GetSection("WordSplit").Value)[1];

            ApplicationUser existingUser = await _userManager.FindByEmailAsync(email);
            _logger.Info("Confirmación de coreo {0}.", email);


            if (existingUser == null)
            {
                string message = string.Format("Correo no encontrado {0}.", email);
                _logger.Error(message);
                throw new NotFoundException(message);
            }

            var result = await _userManager.ConfirmEmailAsync(existingUser, token);


            if (!result.Succeeded)
            {
                string message = string.Format("{0}.", result.Errors);
                _logger.Error(message);
                throw new ConflictException(message);
            }

            return await GetUser(existingUser.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserList>> Users(string? userType, string? order, string? search)
        {
            IEnumerable<UserList> users;
            Expression<Func<ApplicationUser, bool>> filter = null;

            if (!String.IsNullOrEmpty(search))
            {
                filter = o => (o.Name.Contains(search) ||
                                o.LastName.Contains(search) ||
                                o.Email.Contains(search)
                              );
            }
            else
            {
                filter = o => (o.Name != "");
            }

            if (!string.IsNullOrWhiteSpace(userType))
            {
                var listUser = await this._userManager.GetUsersInRoleAsync(userType);
                if (!string.IsNullOrWhiteSpace(order))
                    users = order == "lastName" ? listUser.AsQueryable().Where(filter).ToList().OrderBy(x => x.LastName).Select(x => MapUserList(x)).AsEnumerable()
                    : listUser.AsQueryable().Where(filter).ToList().OrderBy(x => x.Name).Select(x => MapUserList(x)).AsEnumerable();
                else
                    users = listUser.AsQueryable().Where(filter).ToList().Select(x => MapUserList(x)).AsEnumerable();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(order))
                    users = order == "lastName" ? _userManager.Users.Where(filter).OrderBy(x => x.LastName).Select(x => MapUserList(x)).AsEnumerable()
                        : _userManager.Users.Where(filter).ToList().OrderBy(x => x.Name).Select(x => MapUserList(x)).AsEnumerable();
                else
                    users = _userManager.Users.Where(filter).ToList().Select(x => MapUserList(x)).AsEnumerable();
            }


            return users;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<UserList>> UsersInactive(int? top)
        {
            IEnumerable<UserList> users;
            if (top != null)
            {
                users = _context.Users.Where(x => x.Verified == false).Select(x => MapUserList(x)).AsEnumerable();
            }
            else
            {
                users = _context.Users.Select(x => MapUserList(x)).AsEnumerable();
            }
            return Task.FromResult(users);
        }

        public static UserList MapUserList(ApplicationUser x)
        {
            return new UserList
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.Name,
                LastName = x.LastName,
                EmailConfirmed = x.EmailConfirmed,
                Verified = x.Verified,
                //isDocumentsUploaded = x.UrlDocumentId != null && x.UrlDocumentIdBack != null,
                //CreateDate = x.CreateDate
            };
        }

        public static UserResponse MapUserResponse(ApplicationUser x)
        {
            return new UserResponse
            {
                Id = x.Id,
                Email = x.Email,
                Name = x.Name,
                LastName = x.LastName,
                EmailConfirmed = x.EmailConfirmed,
                Verified = x.Verified,
                // isDocumentsUpload = x.UrlDocumentId != null && x.UrlDocumentIdBack != null
            };
        }

        /// <summary>
        /// Get specifc user data
        /// </summary>
        /// <returns></returns>
        public async Task<UserResponse> GetUser(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);


            if (user == null)
            {
                _logger.Error("Usuario no encontrado {0}.", id);
                throw new NotFoundException("Usuario no encontrado.", id);
            }

            List<string> roles = (List<string>)await _userManager.GetRolesAsync(user);

            UserResponse response = new()
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name,
                // Address = user.Address,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Verified = user.Verified,
                // Identification = user.IdDocument,
                // DateOfBirth = user.DateOfBirth != null ? (DateTime)user.DateOfBirth : null,
                EmailConfirmed = user.EmailConfirmed,
                // isDocumentsUpload = user.UrlDocumentId != null && user.UrlDocumentIdBack != null,
                Roles = roles,
                // DocumentBackImage = user.DocumentBackImage,
                // DocumentFrontImage = user.DocumentFrontImage,
                // ProfileImage = user.ProfileImage
            };

            return response;
        }

        public async Task ActivateUser(ActivationUserRequest request)
        {
            ApplicationUser existingUser = await _userManager.FindByIdAsync(request.Id);
            _logger.Info("Activation de usuario {0}.", request.Id);

            if (existingUser == null)
            {
                string message = string.Format("Usuario no encontrado {0}.", request.Id);
                _logger.Error(message);
                throw new NotFoundException(message);
            }
            existingUser.Verified = request.isActivated;
            await _userManager.UpdateAsync(existingUser);

            await SendActivedUserEmail(existingUser);

        }



        public async Task UpdateRegister(RegistrationUpdateRequest request)
        {
            ApplicationUser existingUser = await _userManager.FindByEmailAsync(request.Email);
            _logger.Info("Actualizar registro {0}.", request.Email);

            if (existingUser == null)
            {
                string message = string.Format("Correo no encontrado {0}.", request.Email);
                _logger.Error(message);
                throw new NotFoundException(message);
            }

            if (existingUser.EmailConfirmed == false)
            {
                string message = string.Format("Correo no confirmado {0}.", request.Email);
                _logger.Error(message);
                throw new ConflictException(message);
            }

            //existingUser.Address = request.Address;
            //existingUser.PhoneNumber = request.Phone;
            //existingUser.DateOfBirth = request.DateOfBirth;
            //existingUser.DocumentFrontImage = request.IdDocumentIdentityFrom;
            //existingUser.DocumentBackImage = request.IdDocumentIdentityBack;


            await _userManager.UpdateAsync(existingUser);

            if (!string.IsNullOrWhiteSpace(request.IdDocumentIdentityFrom) && !string.IsNullOrWhiteSpace(request.IdDocumentIdentityBack))
            {
                SendVerificationEmailInProcess(existingUser);
                var emailAdmin = _context.Users.FirstOrDefault(x => x.Email == this._configuration.GetSection("System").GetSection("SupportEmail").Value);
                SendNewVerification(emailAdmin.Email, existingUser);
            }
        }


        public async Task UpdateProfileRegister(RegistrationProfileUpdateRequest request)
        {
            ApplicationUser existingUser = await _userManager.FindByIdAsync(request.Id);

            if (existingUser == null)
            {
                string message = string.Format("Usuario no encontrado {0}.", request.Id);
                _logger.Error(message);
                throw new NotFoundException(message);
            }

            //existingUser.Address = request.Address;
            existingUser.PhoneNumber = request.Phone;
            existingUser.LastName = request.LastName;
            existingUser.Name = request.Name;
            //existingUser.ProfileImage = request.ProfileImage;

            await _userManager.UpdateAsync(existingUser);
        }
        private async void SendNewVerification(string emailAdmin, ApplicationUser user)
        {
            string body = BuildNewVerification(user);
            Email email = new()
            {
                To = emailAdmin,
                Body = body,
                Subject = "DONC - Nueva Verificación.",
            };

            try
            {
                await _emailservice.SendEmail(email);
            }
            catch (Exception)
            {
                string message = string.Format("No se puedo enviar el correo: {0}. Cuerpo del correo {0}.", emailAdmin, body);
                _logger.Error(message);
                throw new Exception(message);
            }
        }

        private string BuildNewVerification(ApplicationUser user)
        {
            string body = $"<p><b>Nuevo usuario por verificar</b></p>";
            body += $"<p>Nombre: {user.Name} {user.LastName}</p>";
            body += $"<p>Correo: {user.Email}</p>";
            return body;
        }

        private async void SendVerificationEmailInProcess(ApplicationUser user)
        {
            List<EmailAttachment> listAttachment = new List<EmailAttachment>();

            listAttachment.Add(new EmailAttachment
            {
                FilePath = Directory.GetCurrentDirectory() + @"\Assets\Image\BodyImageEmail\logo.png",
                Type = "image/png",
                ContentId = "logo",
                Disposition = "inline",
                FileName = "logo.png"
            });

            string body = BuildVerificationEmailInProcess(user);
            Email email = new()
            {
                To = user.Email,
                Body = body,
                Subject = "DONC - Verificación en Proceso.",
                emailAttachments = listAttachment
            };

            try
            {
                await _emailservice.SendEmail(email);
            }
            catch (Exception)
            {
                string message = string.Format("No se puedo enviar el correo : {0}. Cuerpo del correo {1}.", user.Email, body);
                _logger.Error(message);
                throw new Exception(message);
            }
        }

        private string BuildVerificationEmailInProcess(ApplicationUser user)
        {
            string supportEmail = this._configuration.GetSection("System").GetSection("SupportEmail").Value;

            string body = "<div style='text-align: center;'><img src='cid:logo' height = '50px'/></div>";
            body += $"<BR>";
            body += $"<p>Estimado(a) {user.Name.ToUpper()} {user.LastName.ToUpper()}.</p>";
            body += $"<BR>";
            body += $"<BR>";
            body += $"<p>Hemos recibido tus datos y pasamos a validar los mismos.</p>";
            body += $"<BR>";
            body += $"<p>Este proceso puede tardar un par de días.</p>";
            body += $"<p>Una vez validados tus datos recibirás un nuevo correo en donde te indicaremos la activación de tu cuenta.";
            body += $"<p>Si tienes alguna duda puedes contactarnos a través de <a href = 'mailto: {supportEmail}'>{supportEmail}.</p>";
            body += $"<p>Muchas gracias.</p>";
            body += $"<p>El Equipo de Empresa.</p>";

            return body;
        }



        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Boolean> IsAuthorize(AuthRequest request)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                string message = string.Format("Las credendicales son incorrectas: {0}.", request.Email);
                _logger.Error(message);
                throw new ForbiddenException("Las credendicales son incorrectas.");
            }
            if (!user.EmailConfirmed)
            {
                string message = string.Format("Acceso negado. El correo no ha sido confirmado: {0}.", request.Email);
                _logger.Error(message);
                throw new ForbiddenException("Las credendicales son incorrectas.");
            }
            SignInResult result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                if (result.IsNotAllowed)
                    return false;
                else
                    return false;
            }

            return true;
        }

        #region PrivateMethods
        /// <summary>
        /// method to generate a Token JwtSecurityToken
        /// </summary>
        /// <param name="user">Application User</param>
        /// <returns>JwtSecurityToken</returns>
        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim(CustomClaimType.Uid,user.Id)

            }.Union(userClaims).Union(roleClaims);

            var symmetricSecurytyKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurytyKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials
                );

            return jwtSecurityToken;
        }

        /// <summary>
        /// build the body of the confirmation email
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="token">Token</param>
        /// <returns>confirmation email body </returns>
        private string BuildBodyConfirmEmail(string email, string token)
        {

            var recoverUrl = $"{this._configuration.GetSection("AccountSettings").GetSection("Urlbase").Value}{this._configuration.GetSection("AccountSettings").GetSection("EndPointConfirmEmail").Value}";

            var key = $"{email}{this._configuration.GetSection("AccountSettings").GetSection("WordSplit").Value}{token}";
            var keyEncripter = _protector.Protect(key);

            var body = "<div style='text-align: center;'><img src='cid:logo' height = '50px'/></div>";
            body += "<p style='color:#000000'>Te damos la bienvenida a nuestra plataforma de Inversión en Proyectos Inmobiliarios.</p>";
            body += $"<p style='color:#000000'> Para activar tu cuenta debes completar dos pasos.</p>";
            body += $"<p style='color:#000000'>Sigue el siguiente enlace para validar la cuenta de correo electrónico" +
                    $" que nos proporcionaste en el registro y para verificar tu identidad." +
                    $"</p>";
            body += $"<div style='witdh:100%'>";
            body += $"<div style = 'background-color: whitesmoke;text-align: center;'>" +
                          "<div style = 'text-align: center;'>" +
                                "<h1 style = 'color:#000000' > Pasos para activar cuenta </ h1 >" +
                          "</div>" +
                          "<div>" +
                              "<div style = 'display: flex;'>" +
                                    "<div style = 'padding: 20px;width: 50%;'>" +
                                        "<img src='cid:letter' height = '50px'/><br>" +
                                        "<label style = 'color:#000000;text-align: center;'> Validar Correo </label>" +
                                    "</div>" +
                                    "<div style = 'padding: 20px;text-align: center;'>" +
                                        "<img src='cid:card' height = '50px'/><br>" +
                                        "<label style = 'color:#000000' > Verificar tu Identidad</ label>" +
                                    "</div>" +
                               "</div>" +
                            "</div>" +
                    "</div>";
            body += $"<p style='color:#EC6B08'><a style='text-decoration: none; color: white; background-color: #EC6B08; padding: 10px; width: 96%;' href = '{recoverUrl}?key={keyEncripter}'><span style='display: inline-block; width: inherit;text-align: center;'> Enlace </ button ></span></a></p>";
            body += $"</div>";

            body += $"<p style='color:#000000'>  Este mensaje ha sido generado automáticamente.";
            body += $"Si necesitas ayudas o tienes preguntas, envía un correo a XXXXXXX@XXXXXX.com.";
            body += $"<BR>";
            body += $"<p style='color:#000000'> Gracias.</p>";
            body += $"<p style='color:#000000'> El Equipo de Empresa.</p>";

            return body;
        }

        /// <summary>
        /// build the body of the recover password email
        /// </summary>
        /// <param name="userId">user ProgramCategoryId</param>
        /// <param name="token">Token</param>
        /// <returns>recover password email body </returns>
        private async Task<string> BuildBodyRecoverPassword(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                throw new Exception(string.Format("El usuario con el email {0} no existe.", email));
            }

            var recoverUrl = $"{this._configuration.GetSection("AccountSettings").GetSection("Urlbase").Value}{this._configuration.GetSection("AccountSettings").GetSection("EndPointRecoverPassword").Value}";

            var key = $"{email}{this._configuration.GetSection("AccountSettings").GetSection("WordSplit").Value}{token}";
            var keyEncripter = _protector.Protect(key);

            var body = "";
            body += "<div style='text-align: center;'><img src='cid:logo' height = '50px'/></div>";
            body += "<BR>";
            body += "<h4><b>Restablecimiento de Contraseña</b></h4><BR>";
            body += "<p style='color:#000000'>Hola " + user.Name + ".</p>";
            body += $"<p style='color:#000000'>Hemos recibido su solicitud de restablecer la contraseña" +
                    $" de tu cuenta en AtlanticProductClient </p>";
            body += $"<BR>";
            body += $"<BR>";
            body += $"<p style='color:#EC6B08'><a style='text-decoration: none; color: white; background-color: #EC6B08; padding: 10px; width: 96%;' href = '{recoverUrl}?key={keyEncripter}'><span style='display: inline-block; width: inherit;text-align: center;'> Restablecer Contraseña </ button ></span></a></p>";
            body += $"<BR>";
            body += $"<BR>";

            body += "<p style='color:#000000'>Si tiene alguna o necesitas asistencia, no dudes en ponerte en contacto con nuestro equipo de soporte</p>" +
                  "<p style='color:#000000'> Atentamente </p>";

            body += "<p style='color:#000000'>Bolsa y valores</p>";
            return body;
        }

        private async Task<string> BuidlBodyActiviedUserEmail(ApplicationUser user)
        {
            var loginUrl = $"{this._configuration.GetSection("AccountSettings").GetSection("Urlbase").Value}{this._configuration.GetSection("AccountSettings").GetSection("UrlLogin").Value}";
            var SoportEmail = $"{this._configuration.GetSection("System").GetSection("SupportEmail").Value}";


            var body = "";
            body += "<div style='text-align: center;'><img src='cid:logo' height = '50px'/></div>";
            body += $"<BR>";
            body += "<p style='color:#000000'>Estimado(a) inversor(a):" + user.Name + " " + user.LastName + ".</p>";
            body += $"<p style='color:#000000'>Te informamos que su cuenta ya está activa puede ingresar" +
                    $" haciendo clic en el siguiente enlace:  " +
                    $"</p>";
            body += $"<BR>";
            body += $"<BR>";
            body += $"<BR>";
            body += $"<p style='color:#000000'><a style='text-decoration: none; color: white; background-color: #000000; padding: 10px; width: 96%;' href = '{loginUrl}'><span style='display: inline-block; width: inherit;text-align: center;'> Iniciar Sección </ button ></span></a></p>";
            body += $"<BR>";
            body += $"<BR>";
            body += $"<BR>";

            body += $"<p style='color:#000000'>Este mensaje ha sido generado automatomáticamente.</p>" +
                  $"<p style='color:#000000'>Si necesitas ayuda o tienes preguntas, por favor enviar un correo a {SoportEmail}.</p>";
            body += $"<BR>";
            body += $"<p>Gracias.</p>";
            body += $"<BR>";
            body += $"<p>El equipo de Empresa.";

            return body;
        }

        /// <summary>
        /// send confimr email
        /// </summary>
        /// <param name="user">ApplicationUser</param>
        /// <param name="token">Token</param>
        /// <returns></returns>
        private async Task SendConfirmEmail(ApplicationUser user, string token)
        {
            List<EmailAttachment> listAttachment = new List<EmailAttachment>();


            listAttachment.Add(new EmailAttachment
            {

                FilePath = Directory.GetCurrentDirectory() + @"\Assets\Image\BodyImageEmail\logo.png",
                Type = "image/png",
                ContentId = "logo",
                Disposition = "inline",
                FileName = "logo.png"

            });

            listAttachment.Add(new EmailAttachment
            {
                FilePath = Directory.GetCurrentDirectory() + @"\Assets\Image\BodyImageEmail\letter.png",
                Type = "image/png",
                ContentId = "letter",
                Disposition = "inline",
                FileName = "letter.png"

            });
            listAttachment.Add(new EmailAttachment
            {
                FilePath = Directory.GetCurrentDirectory() + @"\Assets\Image\BodyImageEmail\card.png",
                Type = "image/png",
                ContentId = "card",
                Disposition = "inline",
                FileName = "card.png"

            });

            string body = BuildBodyConfirmEmail(user.Email, token);
            Email email = new()
            {
                To = user.Email,
                Body = body,
                Subject = "DONC - Validación de correo electrónico.",
                emailAttachments = listAttachment
            };

            try
            {
                await _emailservice.SendEmail(email);
            }
            catch (Exception)
            {
                _logger.Error("Errors sending confirmation email: {0}.", user.Email);
                string message = string.Format("No se puedo enviar el correo: {0}. Cuerpo del correo {1}", user.Email, body);
                _logger.Error(message);
                throw new Exception(message);
            }
        }

        public AuthenticationProperties GoogleLogin(string? redirectUrl)
        {
            return _signInManager.ConfigureExternalAuthenticationProperties("GOOGLE", redirectUrl);
        }

        public async Task<ExternalLoginInfo> GetExternalLoginInfo()
        {
            List<AuthenticationScheme> pp = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            return await _signInManager.GetExternalLoginInfoAsync();
        }

        public async Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool v)
        {
            List<AuthenticationScheme> pp = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            return await _signInManager.ExternalLoginSignInAsync(loginProvider, providerKey, v);
        }


        /// <summary>
        /// Metodo para registrar usuarios
        /// </summary>
        /// <param name="request"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        /// <exception cref="BadRequestException"></exception>
        /// <exception cref="ConflictException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<string> Register(IUserRegisterData request, string[] roles)
        {
            //if (!request.AcceptPolicies)
            //{
            //    _logger.Error("No ha aceptado las políticas {0}", request.Email);
            //    throw new BadRequestException("Debe aceptar las políticas.");
            //}

            ApplicationUser existingUser = await _userManager.FindByEmailAsync(request.Email);
            _logger.Info("Registro del usuario {0}", request.Email);

            if (existingUser != null)
            {
                _logger.Error("Registro de usuario {0} falló. Usuario ya existe.", request.Email);
                throw new ConflictException("El usuario ya existe.");
            }

            ApplicationUser user = new ApplicationUser
            {
                Email = request.Email,
                Name = request.Name,
                LastName = request.LastName,
                UserName = request.Email,
                EmailConfirmed = true,
                //CreateDate = DateTime.UtcNow,
                //EventOrganizer = request.EventOrganizer,
                //IdDocument = request.IdDocument,


            };

            IdentityResult createUser = await _userManager.CreateAsync(user, request.Password);

            _logger.Info("Usuario registrado {0}.", request.Email);

            if (!createUser.Succeeded)
            {
                throw new Exception($"Error al crear el usuario: {string.Join(", ", createUser.Errors.Select(e => e.Description))}");
            }


            foreach (var role in roles)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            //string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return "";
        }

        public async Task<UserResponse?> GetUserByUserName(string userName)
        {

            var user = await _userManager.FindByEmailAsync(userName);
            if (user != null)
            {
                List<string> roles = (List<string>)await _userManager.GetRolesAsync(user);

                UserResponse response = new()
                {
                    Email = user.Email,
                    Id = user.Id,
                    Name = user.Name,
                    //Address = user.Address,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Verified = user.Verified,
                    //Identification = user.IdDocument,
                    //DateOfBirth = user.DateOfBirth != null ? (DateTime)user.DateOfBirth : null,
                    //EmailConfirmed = user.EmailConfirmed,
                    //isDocumentsUpload = user.UrlDocumentId != null && user.UrlDocumentIdBack != null,
                    Roles = roles,
                    //DocumentBackImage = user.DocumentBackImage,
                    //DocumentFrontImage = user.DocumentFrontImage,
                    //ProfileImage = user.ProfileImage
                };
            }


            return null;

        }


        #endregion

    }
}
