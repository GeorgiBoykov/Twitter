namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Report
    {
        [Key]
        public int Id { get; set; }

        public int TweetId { get; set; }

        [Required]
        [MinLength(5)]
        public string Description { get; set; }

        [ForeignKey("TweetId")]
        public virtual Tweet Tweet { get; set; }

        [Required]
        public string ReporterId { get; set; }

        [ForeignKey("ReporterId")]
        public virtual User Reporter { get; set; }

        public DateTime DateReported { get; set; }
    }
}