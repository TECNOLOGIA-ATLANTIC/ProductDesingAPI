using AtlanticProductDesing.Domain.Common;

namespace AtlanticProductDesing.Domain.Entities
{
    public class Tariff : BaseDomainModel
    {
        public required double SumInsured { get; set; }
        public required double Premium { get; set; }
        public required double Deductible { get; set; }

        public required long CoverageId { get; set; }
        public virtual Coverage? Coverage { get; set; }
    }
}   