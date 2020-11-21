using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WP.Common.Models.Rewards {

    public class RewardProduct {
        
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Cost { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public virtual RewardCategory RewardCategory { get; set; }

        [Required]
        public virtual Employee Employee { get; set; }

    } // class RewardProduct
    
} // namespace WP.Common.Models.Rewards