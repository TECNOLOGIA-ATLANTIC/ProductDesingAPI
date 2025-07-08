using AtlanticProductDesing.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace AtlanticProductDesing.Domain.Entities
{
    public class PolicyFormula : BaseDomainModel, IFormula
    {
        public string Name { get; set; } = string.Empty;

        public string Expression { get; set; } = string.Empty;

        public string? Description { get; set; }

        public long PolicyConfigurationId { get; set; }
        public virtual PolicyConfiguration? PolicyConfiguration { get; set; }
    }
}   