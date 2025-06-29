using AtlanticProductDesing.Domain.Enums;

namespace AtlanticProductDesing.API.Dtos.PersonContact
{
    public class PersonContactMethodDto
    {

        public TypeContactMethod Type { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
