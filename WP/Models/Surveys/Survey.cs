using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WP.Common.Models.Surveys {

    public class Survey {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Points { get; set; }

        [Required]
        public int UserLimit { get; set; }

        public DateTime DateOpen { get; set; }
        
        public DateTime DateClosed { get; set; }

        public virtual ICollection<SurveyQuestion> Questions { get; set; }

    } // class Survey

} // WP.Common.Models.Surveys