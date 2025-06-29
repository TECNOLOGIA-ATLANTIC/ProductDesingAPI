using AtlanticProductDesing.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticProductDesing.Domain.Entities
{
    public class QuotationConfiguration : BaseDomainModel
    {
        public long ProductConfigurationId { get; set; }
        public virtual ProductConfiguration? Product { get; set; }
        public required int VigencyDays { get; set; } = 0;
        public required int ComissionMax { get; set; } = 0;
        public required DateTime ValidFrom { get; set; }
        public required DateTime ValidTo { get; set; }
        public required int Version { get; set; }    
        public string? Description { get; set; } = string.Empty;
        public required string Data { get; set; }



    }
}
