namespace Twitter.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Twitter.Data.Migrations;
    using Twitter.Models;

    public class TwitterDbContext : IdentityDbContext<User>
    {
        public TwitterDbContext()
            : base("name=TwitterDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TwitterDbContext, Configuration>());
        }

        public IDbSet<Tweet> Tweets { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<Report> Reports { get; set; }

        public static TwitterDbContext Create()
        {
            return new TwitterDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Recipient)
                .WithMany()
                .HasForeignKey(m => m.RecipientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tweet>()
                .HasRequired(t => t.Author)
                .WithMany()
                .HasForeignKey(t => t.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tweet>()
                .HasMany(t => t.Replies)
                .WithMany()
                .Map(t => t.MapLeftKey("TweetId").MapRightKey("ReplyTweetId").ToTable("TweetReplies"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.FollowingUsers)
                .WithMany()
                .Map(u => u.MapLeftKey("UserId").MapRightKey("FollowerId").ToTable("Followers"));

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany()
                .Map(u => u.MapLeftKey("UserId").MapRightKey("FollowingUserId").ToTable("FollowingUsers"));

            base.OnModelCreating(modelBuilder);
        }
    }
}