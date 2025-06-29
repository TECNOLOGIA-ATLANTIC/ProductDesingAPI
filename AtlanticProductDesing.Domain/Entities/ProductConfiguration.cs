using AtlanticProductDesing.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticProductDesing.Domain.Entities
{
    public class ProductConfiguration : BaseDomainModel
    {
   
        public required long ProductDesignId { get; set; }
        public virtual ProductDesign? Product {  get; set; }
        public ICollection<Plan> Plans { get; set; } = new List<Plan>();
        public ICollection<QuotationConfiguration> QuotationConfigurations { get; set; } = new List<QuotationConfiguration>();
        public ICollection<PolicyConfiguration> PolicyConfigurations { get; set; } = new List<PolicyConfiguration>();
        public ICollection<ListValue> ListValues { get; set; } = new List<ListValue>();
    }
}
