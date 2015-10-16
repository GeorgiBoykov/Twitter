namespace Twitter.App.Controllers
{
    using System;
    using System.Web.Mvc;

    using Twitter.Data.UnitOfWork;

    using Microsoft.AspNet.Identity;

    using Twitter.App.Models.BindingModels;
    using Twitter.App.Models.ViewModels;
    using Twitter.Models;

    [Authorize]
    [RoutePrefix("tweets")]
    public class TweetsController : BaseController
    {
        public TweetsController()
            : base(new TwitterData())
        {
        }

        [HttpGet]
        [Route("create")]
        public ActionResult NewTweetForm()
        {
            return this.PartialView("_NewTweetModal");
        }

        [HttpPost]
        [Route("add")]
        public ActionResult CreateTweet(CreateTweetBindingModel model)
        {
            var loggedUserId = this.User.Identity.GetUserId();
            var loggedUserUsername = this.User.Identity.GetUserName();

            var tweet = new Tweet { Text = model.Text, AuthorId = loggedUserId, DatePosted = DateTime.Now };

            this.Data.Tweets.Add(tweet);

            this.Data.SaveChanges();

            return this.PartialView(
                "_Tweet",
                new TweetViewModel
                    {
                        Author = loggedUserUsername,
                        DatePosted = tweet.DatePosted,
                        RetweetsCount = tweet.Retweets.Count,
                        RepliesCount = tweet.Replies.Count,
                        Text = tweet.Text,
                        UsersFavouriteCount = tweet.UsersFavourite.Count
                    });
        }
    }
}