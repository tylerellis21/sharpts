using System;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WP.Common.Models.Rewards {

    public partial class UserReward {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Points { get; set; }
        
        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public RewardStatus RewardsStatus { get; set; }

        [Required]
        public virtual User User { get; set; }

        [Required]
        public virtual Employee Employee { get; set; }

        public string Notes { get; set; }
        
    } // class UserReward 
    
} // namespace WP.Common.Models.Rewards
