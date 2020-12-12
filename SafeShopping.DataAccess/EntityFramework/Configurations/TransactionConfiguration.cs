using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.DataAccess.EntityFramework.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ReceiverGuid).IsRequired();
            builder.Property(x => x.ReceiverName).IsRequired();
            builder.Property(x => x.ReceiverLastName).IsRequired();
            builder.Property(x => x.SenderGuid).IsRequired();
            builder.Property(x => x.SenderName).IsRequired();
            builder.Property(x => x.SenderLastName).IsRequired();
            builder.Property(x => x.Balance).IsRequired();
            builder.Property(x => x.DateOfOperation).IsRequired();
            
        }
    }
}
