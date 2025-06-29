namespace AtlanticProductDesing.Application.Models.Identity
{
    public class RegistrationFacebookRequest
    {
        public string provider { get; set; } = string.Empty;
        public string id { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string photoUrl { get; set; } = string.Empty;
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string authToken { get; set; } = string.Empty;
        public string idToken { get; set; } = string.Empty;
        public string authorizationCode { get; set; } = string.Empty;
        public string response { get; set; } = string.Empty;
    }
}


