namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Notification
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public NotificationType Type { get; set; }
    }
}
