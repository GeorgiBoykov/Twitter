﻿namespace Twitter.Data.UnitOfWork
{
    using BookShopSystem.Data.Repositories;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Twitter.Models;

    public interface ITwitterData
    {
        IRepository<Tweet> Tweets { get; }

        IRepository<Message> Messages { get; }

        IRepository<Report> Reports { get; }

        IRepository<User> Users { get; }

        IUserStore<User> UserStore { get; }

        IRepository<IdentityRole> Roles { get; }

        void SaveChanges();
    }
}