using AtlanticProductDesing.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticProductDesing.Domain.Entities
{
    public class DynamicTable: BaseDomainModel
    {
        public required string Name { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public required string Data { get; set; } = string.Empty;
        public long ProductConfigurationId { get; set; }
        public virtual ProductConfiguration? ProductConfiguration { get; set; }
       
    }
}
