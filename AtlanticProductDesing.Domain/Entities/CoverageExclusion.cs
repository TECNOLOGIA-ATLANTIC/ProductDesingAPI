using AtlanticProductDesing.Domain.Common;

namespace AtlanticProductDesing.Domain.Entities
{
    public class CoverageExclusion : BaseDomainModel
    {
        public string? ExclusionDetail { get; set; }

        public required long CoverageId { get; set; }
        public virtual Coverage? Coverage { get; set; }
    }
}   