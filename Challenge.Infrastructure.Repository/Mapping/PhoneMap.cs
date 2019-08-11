using Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Infrastructure.Repository.Mapping
{
    public class PhoneMap
    {
        public PhoneMap(EntityTypeBuilder<Phone> entityBuilder)
        {
            entityBuilder.HasKey(e => e.Id);

            entityBuilder.Property(e => e.AreaCode).IsRequired();
            entityBuilder.Property(e => e.Number).IsRequired();
            entityBuilder.Property(e => e.CreateAt).IsRequired();
            entityBuilder.Property(e => e.UserId).IsRequired();
            entityBuilder.Property(e => e.CountryCode).IsRequired();

            entityBuilder
                .HasOne<User>(u => u.User)
                .WithMany(u => u.Phones)
                .HasForeignKey(ph => ph.UserId);
        }
    }
}
