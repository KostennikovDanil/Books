using BooksDb.Enities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BooksDb
{
    public class BooksDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public BooksDbContext(DbContextOptions<BooksDbContext> options): base(options)
        {

        }
    }
}
