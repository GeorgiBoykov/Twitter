namespace Twitter.App.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.Ajax.Utilities;

    using Twitter.App.Models.ViewModels;
    using Twitter.Data.UnitOfWork;

    [RoutePrefix("users")]
    public class UsersController : BaseController
    {
        public UsersController()
            : base(new TwitterData())
        {
        }

        [Route("search")]
        public ActionResult SearchUser(string searchTerm)
        {
            if (searchTerm.IsNullOrWhiteSpace())
            {
                return this.HttpNotFound();
            }

            var users =
                this.Data.Users.All()
                    .Where(u => u.UserName.Contains(searchTerm))
                    .Select(u => new UserViewModel { Username = u.UserName, Email = u.Email });

            if (!users.Any())
            {
                return this.HttpNotFound();
            }
            
            return this.View(users);
        }
    }
}