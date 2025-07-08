using AtlanticProductDesing.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace AtlanticProductDesing.Domain.Entities
{
    public class SurveyOption : BaseDomainModel
    {
        public required string Value { get; set; } = string.Empty;

        public long SurveyQuestionId { get; set; }
        public virtual SurveyQuestion? SurveyQuestion { get; set; }
    }
}   