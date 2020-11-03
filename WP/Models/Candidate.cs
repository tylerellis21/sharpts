using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WP.Common.Models {

    public class Candidate : User {
        
        [Required]
        public virtual CandidateTitle Title { get; set; }

        // Licences

        // Education/Degrees

        
    } // class Candidate 
    
} // namespace WP.Common.Models