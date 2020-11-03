using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WP.Common.Models.Auth {

    public partial class UserRecovery {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        public string AuthToken { get; set; }

        [Required]
        public DateTime Expires { get; set; }

    } // class UserRecovery

} // namespace WP.Common.Models
