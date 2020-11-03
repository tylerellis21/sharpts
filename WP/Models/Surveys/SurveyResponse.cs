using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WP.Common.Models.Surveys {

    public partial class SurveyResponse {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public virtual Survey Survey { get; set; }

        [Required]
        public virtual SurveyQuestion Question { get; set; }
        
    } // class SurveyResponse

    public partial class SurveyBooleanResponse : SurveyResponse {

        [Required]
        public bool Response { get; set; }
    }

    public partial class SurveyStringResponse : SurveyResponse {

        [Required]
        public string Response { get; set; }
    }
    
    public partial class SurveyeIntegerResponse : SurveyResponse {

        [Required]
        public int Response { get; set; }
    }

} // WP.Common.Models.Surveys