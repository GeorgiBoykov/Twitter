namespace Twitter.App.Controllers
{
    using BookShopSystem.Data.UnitOfWork;

    public class NotificationsController : BaseController
    {
        public NotificationsController()
            : base(new TwitterData())
        {
        }

    }
}