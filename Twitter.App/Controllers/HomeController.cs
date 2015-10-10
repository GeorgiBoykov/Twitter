namespace Twitter.App.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using BookShopSystem.Data.UnitOfWork;

    using Microsoft.AspNet.Identity;

    using Twitter.App.Models.BindingModels;
    using Twitter.App.Models.ViewModels;
    using Twitter.Models;

    [RoutePrefix("home")]
    public class HomeController : BaseController
    {
        public HomeController()
            : base(new TwitterData())
        {
        }

        public ActionResult Index()
        {
            var tweets =
                this.Data.Tweets.All()
                    .Select(
                        t => new TweetViewModel { Author = t.Author.UserName, Text = t.Text, DatePosted = t.DatePosted });

            return this.View(tweets);
        }

        [HttpGet]
        [Route("new-tweet")]
        public ActionResult NewTweetForm()
        {
            return this.View();
        }

        [HttpPost]
        public void CreateTweet(CreateTweetBindingModel model)
        {
            var loggedUserId = this.User.Identity.GetUserId();

            var tweet = new Tweet { Text = model.Text, AuthorId = loggedUserId, DatePosted = DateTime.Now };

            this.Data.Tweets.Add(tweet);

            this.Data.SaveChanges();

            this.RedirectToAction("Index");
        }
    }
}