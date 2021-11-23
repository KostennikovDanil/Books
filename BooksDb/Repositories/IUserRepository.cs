using BooksDb.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksDb.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> All();
    }
}
