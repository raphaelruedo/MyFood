using Microsoft.EntityFrameworkCore;
using MyFood.Domain.Interfaces;
using MyFood.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFood.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly MyFoodContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(MyFoodContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
