using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WP.Common.Models {

    public class JobCandidate {
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Job Job { get; set; }

        public Candidate Candidate { get; set; }
        
    } // class JobCandidate
    
} // namespace WP.Common.Models