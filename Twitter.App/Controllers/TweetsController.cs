namespace Twitter.App.Controllers
{
    using System;
    using System.Web.Mvc;

    using BookShopSystem.Data.UnitOfWork;

    using Microsoft.AspNet.Identity;

    using Twitter.App.Models.BindingModels;
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
            return this.View();
        }

        [HttpPost]
        [Route("add")]
        public void CreateTweet(CreateTweetBindingModel model)
        {
            var loggedUserId = this.User.Identity.GetUserId();

            var tweet = new Tweet { Text = model.Text, AuthorId = loggedUserId, DatePosted = DateTime.Now };

            this.Data.Tweets.Add(tweet);

            this.Data.SaveChanges();
        }
    }
}