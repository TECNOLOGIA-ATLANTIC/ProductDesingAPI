using AtlanticProductDesing.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticProductDesing.Domain.Entities
{
    public class ListValue : BaseDomainModel
    {
        public required string Name { get; set; }
        public IEnumerable<ValueListValue> Values { get; set; } = new List<ValueListValue>();

        public long ProductConfigurationId { get; set; }
        public virtual ProductConfiguration? ProductConfiguration { get; set; }
    }
}
