using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDb.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> All();
        Task AddAsync(T source);
        bool Update(T source);
        bool Remove(T source);
        Task SaveChangesAsync();
    }
}
