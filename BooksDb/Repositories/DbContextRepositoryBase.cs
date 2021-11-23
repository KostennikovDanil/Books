using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDb.Repositories
{
    public abstract class DbContextRepositoryBase<T, TKey> : IRepository<T>
        where T : class, IEntityKey<TKey>
    {
        protected readonly DbContext db;
        public DbContextRepositoryBase(DbContext db)
        {
            this.db = db;
        }
        public async Task AddAsync(T source)
        {
            await db.Set<T>().AddAsync(source);
        }

        public IQueryable<T> All()
        {
            return AllInclude(db.Set<T>());
        }

        public bool Remove(T source)
        {
            var original = db.Set<T>().Find(source.Id);
            if (original == null)
                return false;
            return true;
        }

        public async Task SaveChangesAsync()
        {
            await db.SaveChangesAsync();
        }

        public bool Update(T source)
        {
            var original = db.Set<T>().Find(source.Id);
            if (original == null)
                return false;


            return true;
        }

        protected abstract IQueryable<T> AllInclude(IQueryable<T> source);
    }
}
