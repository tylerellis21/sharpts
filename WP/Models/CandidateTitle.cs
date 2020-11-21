using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WP.Common.Models {

    public class CandidateTitle {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Abbreviation { get; set; }

        public string FullName { get; set; }
        
        [StringLength(6)]
        public string Color { get; set; }

    } // class CandidateTitle
    
} // namespace WP.Common.Models