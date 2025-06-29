using AtlanticProductDesing.Domain.Common;

namespace AtlanticProductDesing.Domain.Entities
{
    public class Deductible : BaseDomainModel
    {
        public required double Amount { get; set; }

        public required long PlanId { get; set; }
        public virtual Plan? Plan { get; set; }
    }
}   