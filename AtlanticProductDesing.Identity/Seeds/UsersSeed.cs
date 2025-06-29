using AtlanticProductClient.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace AtlanticProductClient.Identity.Seeds
{
    public class UsersSeed
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersSeed(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task Run()
        {

            ApplicationUser[] userInvestors = GetUserInvestor();


            foreach (ApplicationUser user in userInvestors)
            {

                await _userManager.CreateAsync(user, "Koi.123");

                await _userManager.AddToRoleAsync(user, "Investor");
            }
        }

        private ApplicationUser[] GetUserInvestor()
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            ApplicationUser[] userList = new ApplicationUser[] {
                new ApplicationUser
                {
                    Id = "649de035-a55b-44a3-9b70-de71570be3e2",
                    Email = "juzcategui@wcslat.com",
                    NormalizedEmail = "juzcategui@wcslat.com",
                    Name = "Jonathan",
                    LastName = "Uzcategui",
                    UserName = "juzcategui@wcslat.com",
                    NormalizedUserName = "juzcategui@wcslat.com",
                    PasswordHash = hasher.HashPassword(null, "@ngelo070507"),
                    EmailConfirmed = true,
                    Verified = false,
                    DateOfVerification = DateTime.Now,


                },
                new ApplicationUser
                {
                    Id = "b95f387d-fc98-4606-aad7-8ad1b30b488f",
                    Email = "mbetancourt@wcslat.com",
                    NormalizedEmail = "mbetancourt@wcslat.com",
                    Name = "Mitchael",
                    LastName = "Betancourt",
                    UserName = "mbetancourt@wcslat.com",
                    NormalizedUserName = "mbetancourt@wcslat.com",
                    PasswordHash = hasher.HashPassword(null, "Abc.123"),
                    EmailConfirmed = true,
                    Verified = true,
                    DateOfVerification = DateTime.Now,


                },
                new ApplicationUser
                {
                    Id = "c0a16b81-e3eb-413d-8092-9bcc3637166c",
                    Email = "jheysson.diaz@koibanx.com",
                    NormalizedEmail = "JHEYSSON.DIAZ@KOIBANX.COM",
                    Name = "Jheysson",
                    LastName = "Diaz",
                    UserName = "jheysson.diaz@koibanx.com",
                    NormalizedUserName = "jheysson.diaz@koibanx.com",
                    PasswordHash = hasher.HashPassword(null, "Koi.123"),
                    EmailConfirmed = true,
                    Verified = true,
                    DateOfVerification = DateTime.Now,


                },
                new ApplicationUser
                {
                    Id = "2027e755-c9a5-40bb-abf5-079911545287",
                    Email = "jdiaz@wcloudservices.com",
                    NormalizedEmail = "JDIAZ@WCLOUDSERVICES.COM",
                    Name = "Jheysson J",
                    LastName = "Diaz",
                    UserName = "jdiaz@wcloudservices.com",
                    NormalizedUserName = "jdiaz@wcloudservices.com",
                    PasswordHash = hasher.HashPassword(null, "Koi.123"),
                    EmailConfirmed = true,
                    Verified = true,
                    DateOfVerification = DateTime.Now,


                },
                new ApplicationUser
                {
                    Id = "40b8cd65-d8e3-4810-b488-3b911599ad5a",
                    Email = "lromero@wcslat.com",
                    NormalizedEmail = "LROMERO@WCSLAT.COM",
                    Name = "Luis",
                    LastName = "Romero",
                    UserName = "lromero@wcslat.com",
                    NormalizedUserName = "lromero@wcslat.com",
                    PasswordHash = hasher.HashPassword(null, "Koi.123"),
                    EmailConfirmed = true,
                    Verified = true,
                    DateOfVerification = DateTime.Now,


                },
                new ApplicationUser
                {
                    Id = "0a937129-539d-4aa3-96f5-5e929d8a189d",
                    Email = "jblanco@wcslat.com",
                    NormalizedEmail = "jblanco@wcslat.com",
                    Name = "Juan",
                    LastName = "Blanco",
                    UserName = "jblanco@wcslat.com",
                    NormalizedUserName = "jblanco@wcslat.com",
                    PasswordHash = hasher.HashPassword(null, "Koi.123"),
                    EmailConfirmed = true,
                    Verified = true,
                    DateOfVerification = DateTime.Now,


                },
                new ApplicationUser
                {
                    Id = "10f24485-5bff-43de-9790-65ad0914a94a",
                    Email = "juan.blanco@koibanx.com",
                    NormalizedEmail = "JUAN.BLANCO@KOIBANX.COM",
                    Name = "Juan",
                    LastName = "Blanco",
                    UserName = "juan.blanco@koibanx.com",
                    NormalizedUserName = "juan.blanco@koibanx.com",
                    PasswordHash = hasher.HashPassword(null, "Koi.123"),
                    EmailConfirmed = true,
                    Verified = true,
                    DateOfVerification = DateTime.Now,


                },
                new ApplicationUser
                {
                    Id = "c58af586-5bc6-4777-b335-7d9841590a95",
                    Email = "gceballos@wcslat.com",
                    NormalizedEmail = "GCEBALLOS@WCSLAT.COM",
                    Name = "Gabriela",
                    LastName = "Ceballo Investor",
                    UserName = "gceballos@wcslat.com",
                    NormalizedUserName = "gceballos@wcslat.com",
                    PasswordHash = hasher.HashPassword(null, "Koi.123"),
                    EmailConfirmed = true,
                    Verified = true,
                    DateOfVerification = DateTime.Now,

                },
                new ApplicationUser
                {
                    Id = "749d47c1-6ca7-416b-8cee-4e6611178633",
                    Email = "luis.olaizola@koibanx.com",
                    NormalizedEmail = "LUIS.OLAIZOLA@KOIBANX.COM",
                    Name = "Luis",
                    LastName = "Olaizola Admin",
                    UserName = "luis.olaizola@koibanx.com",
                    NormalizedUserName = "luis.olaizola@koibanx.com",
                    PasswordHash = hasher.HashPassword(null, "Koi.123"),
                    EmailConfirmed = true,
                    Verified = true,
                    DateOfVerification = DateTime.Now,


                },
                new ApplicationUser
                {
                    Id = "13078bcf-2cff-4d44-b4f4-c1e577cff80e",
                    Email = "lolaizola@wcslat.com",
                    NormalizedEmail = "LOLAIZOLA@WCSLAT.COM",
                    Name = "Luis",
                    LastName = "Olaizola Investor",
                    UserName = "lolaizola@wcslat.com",
                    NormalizedUserName = "lolaizola@wcslat.com",
                    PasswordHash = hasher.HashPassword(null, "Koi.123"),
                    EmailConfirmed = true,
                    Verified = true,
                    DateOfVerification = DateTime.Now,

                },
                new ApplicationUser
                {
                    Id = "d795f785-0ba4-42d7-b72f-843993f846ab",
                    Email = "mendozakevin@gmail.com",
                    NormalizedEmail = "MENDOZAKEVIN@GMAIL.COM",
                    Name = "Kevin",
                    LastName = "Mendoza",
                    UserName = "mendozakevin@gmail.com",
                    NormalizedUserName = "mendozakevin@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Mendoza2*"),
                    EmailConfirmed = true,
                    Verified = true,
                    DateOfVerification = DateTime.Now,


                }
            };
            return userList;

        }
    }
}
