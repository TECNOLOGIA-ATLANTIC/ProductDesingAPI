namespace AtlanticProductDesing.Application.Models.Identity
{
    public class UpdatePasswordRequest
    {
        public string ActualPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
