using AtlanticProductDesing.Domain.Common;
using AtlanticProductDesing.Domain.Enums;
using AtlanticProductDesing.Domain.Interfaces;

namespace AtlanticProductDesing.Domain.Entities
{
    public class PersonContactMethod : BaseDomainModel, IContactMethod
    {
        public long PersonId { get; set; }
        virtual public Person Person { get; set; }
        public required TypeContactMethod Type { get; set; }
        public required string Description { get; set; } = string.Empty;
        public required string Value { get; set; } = string.Empty;
    }
}
