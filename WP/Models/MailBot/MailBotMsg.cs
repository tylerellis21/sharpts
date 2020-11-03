using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WP.Common.Models {

    public partial class MailBotMsg {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public bool Sent { get; set; }

        // This is an optional field that defaults to null
        // If set, the mail bot will wait until this time has passed until it tries to send out this message.
        
        public DateTime? QueueTime { get; set; }

    } // class MailBotQueue 
    
} // namespace WP.Common.Models