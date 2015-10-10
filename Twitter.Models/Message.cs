namespace Twitter.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SenderId { get; set; }

        [Required]
        public string RecipientId { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Recipient { get; set; }
    }
}