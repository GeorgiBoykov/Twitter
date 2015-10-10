namespace Twitter.App.Controllers
{
    using System.Web.Mvc;

    using Twitter.Data.UnitOfWork;

    public class BaseController : Controller
    {
        protected BaseController(ITwitterData data)
        {
            this.Data = data;
        }

        protected ITwitterData Data { get; }
    }
}