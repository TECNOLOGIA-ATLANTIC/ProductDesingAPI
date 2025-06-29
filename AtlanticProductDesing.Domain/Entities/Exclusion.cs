using AtlanticProductDesing.Domain.Common;

namespace AtlanticProductDesing.Domain.Entities
{
    public class Exclusion : BaseDomainModel
    {
        public string? ExclusionDetail { get; set; }

        public required long PlanId { get; set; }
        public virtual Plan? Plan { get; set; }
    }
}   