namespace Twitter.App.Controllers
{
    using BookShopSystem.Data.UnitOfWork;

    public class TweetsController : BaseController
    {
        public TweetsController()
            : base(new TwitterData())
        {
        }
    }
}