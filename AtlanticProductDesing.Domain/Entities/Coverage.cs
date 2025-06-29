using AtlanticProductDesing.Domain.Common;
using System.Collections.Generic;

namespace AtlanticProductDesing.Domain.Entities
{
    public class Coverage : BaseDomainModel
    {
        public string? CoverageName { get; set; }
        public required long PlanId { get; set; }
        public virtual Plan? Plan { get; set; }

        public virtual ICollection<Tariff>? Tariffs { get; set; }
        public virtual ICollection<CoverageExclusion>? CoverageExclusions { get; set; }
    }
}