using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WP.Common.Models {

    public class PhysicalAddress {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // TODO(@Tyler): Should we create tables with a list of countries, states?
        // [Required]
        public string Country { get; set; } = "";

        // [Required]
        public string State { get; set; } = "";

        // [Required]
        public string City { get; set; } = "";

        // [Required]
        public string Zip { get; set; } = "";

        // [Required]
        public decimal Latitude { get; set; } = 0M;

        // [Required]
        public decimal Longitude { get; set; } = 0M;
        
    } // class Address 
    
} // namespace WP.Common.Models