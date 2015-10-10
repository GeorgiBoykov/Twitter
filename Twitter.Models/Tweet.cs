namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        public Tweet()
        {
            this.Likers = new HashSet<User>();
            this.Replies = new HashSet<Tweet>();
            this.Reports = new HashSet<Report>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string Text { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public User Author { get; set; }

        public DateTime DatePosted { get; set; }

        public virtual ICollection<User> Likers { get; set; }

        public virtual ICollection<Tweet> Replies { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}