using BooksDb.Enities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BooksDb.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly BooksDbContext db;
        public UserRepository(BooksDbContext db)
        {
            this.db = db;
        }

        protected IQueryable<User> AllInclude(IQueryable<User> source)
        {
            return AllInclude(db.Set<User>());
        }
        protected IQueryable<User> ByKeyInclude(IQueryable<User> source)
        {
            return AllInclude(db.Set<User>());
        }
    }
}
}
