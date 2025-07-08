using AtlanticProductDesing.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtlanticProductDesing.Domain.Entities
{
    public class Survey : BaseDomainModel
    {
       
        public required string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ICollection<SurveyQuestion> Questions { get; set; } = new List<SurveyQuestion>();
    }
}   