namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Tweet
    {
        public Tweet()
        {
            this.Favourers = new HashSet<User>();
            this.Replies = new HashSet<Tweet>();
            this.Reports = new HashSet<Report>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Text { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public DateTime DatePosted { get; set; }

        public virtual ICollection<User> Favourers { get; set; }

        public virtual ICollection<Tweet> Replies { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}