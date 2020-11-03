using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WP.Common.Models.Auth {

    public partial class AuthSession {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public virtual User User { get; set; } 

        [Required]
        public DateTime Expires { get; set; }

        [Required]
        public string AuthToken { get; set; }

        [NotMapped]
        public bool IsValid { get { return Expires > DateTime.Now; } }

    }
} // namespace WP.Common.Models