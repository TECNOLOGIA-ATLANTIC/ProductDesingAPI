using AtlanticProductDesing.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticProductDesing.Domain.Entities
{
    public class Plan : BaseDomainModel
    {
        public long ProductConfigurationId { get; set; }
        public virtual ProductConfiguration? Product { get; set; }      
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public required string Data { get; set; } = string.Empty;
        public ICollection<Coverage> Coverages { get; set; } = new List<Coverage>();   
        public ICollection<Deductible> Deductibles { get; set; } = new List<Deductible>();
        public ICollection<Exclusion> Exclusions { get; set; } = new List<Exclusion>();
   }
    
}
