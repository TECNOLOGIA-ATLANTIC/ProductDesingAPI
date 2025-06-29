using Microsoft.AspNetCore.Identity;

namespace AtlanticProductClient.Identity.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
