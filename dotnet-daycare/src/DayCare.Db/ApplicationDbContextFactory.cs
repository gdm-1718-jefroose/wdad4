using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using DayCare.Models;
using DayCare.Models.Security;

namespace DayCare.Db
{
    public class ApplicationDbContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseNpgsql("User ID=originaljef;Password=postgres;Host=localhost;Port=5432;Database=daycare;Pooling=true;");
            return new ApplicationDbContext(builder.Options);
        }
    }
}