using AtlanticProductDesing.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace AtlanticProductDesing.Domain.Entities
{
    public class CertificateFormula : BaseDomainModel, IFormula
    {
        public string Name { get; set; } = string.Empty;

        public string Expression { get; set; } = string.Empty;

        public string? Description { get; set; }

        public long CertificateId { get; set; }
        // public virtual Certificate? Certificate { get; set; } // Descomenta si tienes la entidad Certificate
    }
}   