using AtlanticProductDesing.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticProductDesing.Domain.Entities
{
    public class ProductDesign : BaseDomainModel
    {
     
        public string Description { get; set; }
        public long ClientId { get; set; }
        public long CountryId { get; set; }
        public long ProductId { get; set; }

    }
}
