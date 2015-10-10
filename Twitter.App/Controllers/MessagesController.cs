namespace Twitter.App.Controllers
{
    using BookShopSystem.Data.UnitOfWork;

    public class MessagesController : BaseController
    {
        public MessagesController()
            : base(new TwitterData())
        {
        }
    }
}