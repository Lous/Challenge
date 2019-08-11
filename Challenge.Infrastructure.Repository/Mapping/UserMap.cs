using Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Infrastructure.Repository.Mapping
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);

            entityBuilder.Property(e => e.CreateAt).IsRequired();
            entityBuilder.Property(e => e.Firstname).IsRequired();
            entityBuilder.Property(e => e.Lastname).IsRequired();
            entityBuilder.Property(e => e.Email).IsRequired();
            entityBuilder.Property(e => e.Password).IsRequired();
            entityBuilder.Property(e => e.LastAccess).IsRequired();
        }
    }
}
