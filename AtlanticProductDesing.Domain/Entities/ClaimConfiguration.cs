using AtlanticProductDesing.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace AtlanticProductDesing.Domain.Entities
{
    public class ClaimConfiguration : BaseDomainModel
    {
        public long ProductConfigurationId { get; set; }
        public virtual ProductConfiguration? Product { get; set; }
        public string? Description { get; set; } = string.Empty;
        public required string Data { get; set; } = string.Empty;
    }
}   