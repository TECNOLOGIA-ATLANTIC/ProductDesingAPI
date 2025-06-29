using AtlanticProductClient.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AtlanticProductClient.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.HasData(
                new ApplicationUserRole
                {
                    RoleId = "8e1aee4a-317c-4445-b4b2-904f9dd56697", // Gabriela Ceballos admin
                    UserId = "dee8c53e-e054-4b69-a8c3-acd656df4e09"
                }
            );
        }
    }
}
