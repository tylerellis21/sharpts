using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WP.Common.Models {

    public class Job {
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public virtual Hospital Hospital { get; set; }

        [Required]
        public virtual Employee Owner { get; set; }

        [Required]
        public int Salary { get; set; }

        //acting
        //former
        //interm
        //hr_manager
        //job boss
        //job_contract
        //job_open
        //job_receptive
        //job retained
        //hidefrommap
        public bool HideFromMap { get; set; } = false;

        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }

        public virtual ICollection<JobCandidate> Candidates { get; set; }
        public virtual ICollection<JobOwner> Owners { get; set; }
        
    } // class Job 
    
} // namespace WP.Common.Models