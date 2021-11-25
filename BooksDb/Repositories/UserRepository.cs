using BooksDb.Enities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksDb.Repositories
{
    public class UserRepository : DbContextRepositoryBase<User, int>, IUserRepository
    {
        public UserRepository(BooksDbContext db): base(db)
        {
        }

        protected override IQueryable<User> AllInclude(IQueryable<User> source)
        {
            return AllInclude(db.Set<User>());
        }


        protected IQueryable<User> ByKeyInclude(IQueryable<User> source)
        {
            return AllInclude(db.Set<User>());
        }
    }
}

