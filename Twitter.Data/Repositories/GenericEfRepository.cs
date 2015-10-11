﻿namespace Twitter.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public class GenericEfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly DbContext dbContext;

        public GenericEfRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.EntitySet = dbContext.Set<TEntity>();
        }

        public IDbSet<TEntity> EntitySet { get; private set; }

        public IQueryable<TEntity> All()
        {
            return this.EntitySet;
        }

        public TEntity Find(object id)
        {
            return this.EntitySet.Find(id);
        }

        public void Add(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Remove(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public TEntity Remove(object id)
        {
            var entity = this.Find(id);
            this.Remove(entity);
            return entity;
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private void ChangeState(TEntity entity, EntityState state)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.EntitySet.Attach(entity);
            }

            entry.State = state;
        }
    }
}