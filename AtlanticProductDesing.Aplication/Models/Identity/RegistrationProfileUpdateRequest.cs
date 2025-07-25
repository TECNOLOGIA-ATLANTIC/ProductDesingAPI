﻿namespace AtlanticProductDesing.Application.Models.Identity
{
    public class RegistrationProfileUpdateRequest
    {
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public string? ProfileImage { get; set; } = string.Empty;
    }
}
