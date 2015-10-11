namespace Twitter.Models
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        public User()
        {
            this.Tweets = new HashSet<Tweet>();
            this.Followers = new HashSet<User>();
            this.FollowingUsers = new HashSet<User>();
        }

        public virtual ICollection<Tweet> Tweets { get; set; }

        public virtual ICollection<User> FollowingUsers { get; set; }

        public virtual ICollection<User> Followers { get; set; }

        public virtual ICollection<Tweet> FavouriteTweets { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}