using AtlanticProductDesing.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticProductDesing.Domain.Entities
{
    public class CertificateConfiguration : BaseDomainModel
    {
        public long ProductConfigurationId { get; set; }
        public virtual ProductConfiguration? Product { get; set; }
    
        public string? Description { get; set; } = string.Empty;
        public required string Data { get; set; } = string.Empty;
    }
}
