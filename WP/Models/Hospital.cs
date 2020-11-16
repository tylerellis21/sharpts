using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WP.Common.Models {

    public enum HospitalType { 
        None = 0,
    }

    public class Hospital {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public virtual PhysicalAddress Address { get; set; }

        public virtual Employee CreatedByEmployee { get; set; }

        [Required]
        public DateTime CreatedDate;

        public HospitalType Type { get; set; }

        public string Telephone { get; set; }
        public string Image { get; set; }
        public string Website { get; set; }

        // Better name?? and Type??
        public string Cases { get; set; }

        // Better name??
        // What is status used for?
        public int Status { get; set; }
        public int Beds { get; set; }
        public int ORSuites { get; set; }
        public int CaseVolume { get; set; }
        public int Ftes { get; set; }

        public virtual Hospital Parent { get; set; }

        public virtual ICollection<Hospital> ChildrenHospitals { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public Hospital GetRootParent() {
            Hospital pointer = this;
            while (pointer.Parent != null) {
                pointer = pointer.Parent;
            }
            return pointer;
        }
    } // class Hospital 
    
} // namespace WP.Common.Models