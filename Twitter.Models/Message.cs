namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SenderId { get; set; }

        public virtual User Sender { get; set; }

        [Required]
        public string RecipientId { get; set; }

        public virtual User Recipient { get; set; }

        [Required]
        [MinLength(1)]
        public string Content { get; set; }

        public DateTime DateSent { get; set; }
    }
}