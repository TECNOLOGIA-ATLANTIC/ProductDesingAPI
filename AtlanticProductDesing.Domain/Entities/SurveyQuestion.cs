using AtlanticProductDesing.Domain.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtlanticProductDesing.Domain.Entities
{
    public enum QuestionType
    {
        SingleChoice, // Selecci�n simple (S�/No, opciones)
        Number,
        Text
    }

    public class SurveyQuestion : BaseDomainModel
    {
        [Required]
        public string Text { get; set; } = string.Empty;

        [Required]
        public QuestionType Type { get; set; }

        public long SurveyId { get; set; }
        public virtual Survey? Survey { get; set; }

        // Opciones para selecci�n simple (solo aplica si Type == SingleChoice)
        public ICollection<SurveyOption> Options { get; set; } = new List<SurveyOption>();
    }
}   