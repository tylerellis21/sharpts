using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WP.Common.Models {

    public class User {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required()]
        public UserType UserType { get; set; }

        [Required()]
        [StringLength(128)]
        public string FirstName { get; set; }

        [StringLength(128)]
        public string MiddleName { get; set; }

        [Required()]
        [StringLength(128)]
        public string LastName { get; set; }

        [Required]
        public UserGender Gender { get; set; }

        [Required()]
        public virtual PhysicalAddress Address { get; set; }

        public string Telephone { get; set; }
        
        public bool IsRegistered { get; set; } 

        public bool IsLocked { get; set; }

        public bool IsDead { get; set; }
        
        [Required()] 
        public bool IsActive { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [MinLength(3)]
        [MaxLength(24)]
        public string Nickname { get; set; }

        [Required()]        
        [MinLength(3)]
        [MaxLength(24)]
        public string Password { get; set; }
        
        [Required()]        
        [MinLength(3)]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required()]
        // Date the user was added into the database
        public DateTime CreationDate { get; set; }


    } // class User

} // namespace WP.Common.Models
