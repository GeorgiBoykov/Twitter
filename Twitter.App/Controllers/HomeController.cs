namespace Twitter.App.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Twitter.Data.UnitOfWork;

    using Microsoft.AspNet.Identity;

    using Twitter.App.Models.BindingModels;
    using Twitter.App.Models.ViewModels;
    using Twitter.Models;

    [Authorize]
    [RoutePrefix("home")]
    public class HomeController : BaseController
    {
        public HomeController()
            : base(new TwitterData())
        {
        }

        public ActionResult Index()
        {
            var recentTweets =
                this.Data.Tweets.All()
                    .Select(
                        t => new TweetViewModel
                                 {
                                    Author = t.Author.UserName,
                                    Text = t.Text,
                                    DatePosted = t.DatePosted
                                 })
                    .Take(10);

            return this.View(recentTweets);
        }
    }
}