namespace Twitter.App.Controllers
{
    using Twitter.Data.UnitOfWork;

    public class MessagesController : BaseController
    {
        public MessagesController()
            : base(new TwitterData())
        {
        }
    }
}