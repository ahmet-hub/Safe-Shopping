using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.DataAccess.EntityFramework.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
     
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);  
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.Property(x => x.SurName).IsRequired().HasMaxLength(20);           
            builder.HasIndex(x => x.IdentificationNumber).IsUnique();
            builder.Property(x => x.DateOfBirth).IsRequired();
            //builder.Property(x => x.Balance).HasDefaultValue();
            //builder.Property(x => x.SuccessfulOperationCount).HasDefaultValue();
           
        }
    }
}
