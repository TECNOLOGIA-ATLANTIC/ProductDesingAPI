using AtlanticProductClient.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AtlanticProductClient.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            builder.HasData(
                new ApplicationUser
                {
                    Id = "dee8c53e-e054-4b69-a8c3-acd656df4e09",// ADMINISTRATOR
                    Email = "gabriela.ceballos@koibanx.com",
                    NormalizedEmail = "GABRIELA.CEBALLOS@KOIBANX.COM",
                    Name = "Gabriela",
                    LastName = "Ceballo Admin",
                    UserName = "gabriela.ceballos@koibanx.com",
                    NormalizedUserName = "gabriela.ceballos@koibanx.com",
                    PasswordHash = hasher.HashPassword(null, "Koi.123"),
                    EmailConfirmed = true,
                    Verified = true,
                    DateOfVerification = DateTime.Now,

                }
            );
        }
    }
}
