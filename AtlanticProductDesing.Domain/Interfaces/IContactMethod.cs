using AtlanticProductDesing.Domain.Enums;

namespace AtlanticProductDesing.Domain.Interfaces
{
    public interface IContactMethod
    {
        public TypeContactMethod Type { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }

    }
}
