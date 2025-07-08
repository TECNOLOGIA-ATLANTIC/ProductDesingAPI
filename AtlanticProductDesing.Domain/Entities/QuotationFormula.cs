using AtlanticProductDesing.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace AtlanticProductDesing.Domain.Entities
{
    public class QuotationFormula : BaseDomainModel, IFormula
    {
        public string Name { get; set; } = string.Empty;

        public string Expression { get; set; } = string.Empty;

        public string? Description { get; set; }

        public long QuotationConfigurationId { get; set; }
        public virtual QuotationConfiguration? QuotationConfiguration { get; set; }
    }
}   