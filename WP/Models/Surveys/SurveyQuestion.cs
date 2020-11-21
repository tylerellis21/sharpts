using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WP.Common.Models.Surveys {
    
    public enum SurveyQuestionType {
        Null = 0,
        Boolean,
        MultipleChoice,
        Text,
        Integer,
        Email
    }

    public partial class SurveyQuestion {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("SurveyId")]
        public int SurveyId { get; set; }

        [Required]
        public SurveyQuestionType Type { get; set; }

        [Required]
        public string Question { get; set; }

        public virtual ICollection<SurveyResponse> Responses { get; set; }
        
    } // class SurveyQuestion
    
    public partial class SurveyMultipleChoice {

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("QuestionId")]
        public int QuestionId { get; set; }

 
        public string Choice { get; set; }
    }

    public partial class SurveyMultipleChoiceQuestion : SurveyQuestion {
        public ICollection<SurveyMultipleChoice> Choices { get; set; }
    }

} // WP.Common.Models.Surveys