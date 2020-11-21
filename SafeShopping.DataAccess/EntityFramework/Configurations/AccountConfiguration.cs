using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.DataAccess.EntityFramework.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        //public void Configure(EntityTypeBuilder<Account> builder)
        //{

        //    builder.HasKey(x => x.Id);
        //    builder.Property(x=>x.MyGuid).UseIdentityColumn()
        //}
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(20);           
            builder.HasIndex(x => x.IdentificationNumber).IsUnique();
            builder.Property(x => x.DateOfBirth).IsRequired();
           
        }
    }
}
