namespace Twitter.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Report
    {
        [Key]
        public int Id { get; set; }

        public int TweetId { get; set; }

        [ForeignKey("TweetId")]
        public virtual Tweet Tweet { get; set; }
    }
}