namespace Twitter.App.Models.ViewModels
{
    using System;

    public class TweetViewModel
    {
        public string Author { get; set; }

        public string Text { get; set; }

        public DateTime DatePosted { get; set; }
    }
}