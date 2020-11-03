using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WP.Common.Models {

    public class JobOwner {
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public virtual Job Job { get; set; }

        [Required]
        public virtual Employee Owner { get; set; }
        
    } // class JobOwner 
    
} // namespace WP.Common.Models