using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtlanticProductDesing.Domain.Entities
{
    public class ValueListValue
    {
        public required string Key { get; set; }
        public required string Value { get; set; }
        public long ListValueId { get; set; }
        public virtual ListValue ListValue { get; set; } = null!;
    }
}
