using Challenge.Domain.Entities;
using Challenge.Infrastructure.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Infrastructure.Repository.Configurations
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new PhoneMap(modelBuilder.Entity<Phone>());

            new UserMap(modelBuilder.Entity<User>());
        }
    }
}
