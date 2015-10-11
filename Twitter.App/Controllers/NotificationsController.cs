namespace Twitter.App.Controllers
{
    using Twitter.Data.UnitOfWork;

    public class NotificationsController : BaseController
    {
        public NotificationsController()
            : base(new TwitterData())
        {
        }

    }
}