using AtlanticProductClient.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AtlanticProductClient.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {


            builder.HasData(
                new ApplicationRole
                {
                    Id = "8e1aee4a-317c-4445-b4b2-904f9dd56697",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                  new ApplicationRole
                  {
                      Id = "69cc99ac-dd56-4dd6-a788-ba54785a765c",
                      Name = "Operator",
                      NormalizedName = "OPERATOR"
                  },
                   new ApplicationRole
                   {
                       Id = "08c8ed8a-05ab-4cc3-8940-92279210bb4e",
                       Name = "OwnerEvent",
                       NormalizedName = "OwnerEvent"
                   }
                );
        }
    }
}
