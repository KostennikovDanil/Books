using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksDb
{
    class BooksDbDesignTimeDbContextFactory : IDesignTimeDbContextFactory<BooksDbContext>
    {
        public BooksDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .Build();
            var builder = new DbContextOptionsBuilder<BooksDbContext>();
            //var connectionString = configuration.GetConnectionString("PostgresConnection");
            var connectionString = "Server=localhost;Port=5434;Database=books_db;User Id='postgres';Password=1234";
            builder.UseNpgsql(connectionString);
            return new BooksDbContext(builder.Options);
        }
    }
}
