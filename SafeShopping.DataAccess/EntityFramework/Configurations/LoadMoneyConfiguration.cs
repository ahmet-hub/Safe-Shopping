using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.DataAccess.EntityFramework.Configurations
{
    public class LoadMoneyConfiguration : IEntityTypeConfiguration<LoadMoney>
    {
        public void Configure(EntityTypeBuilder<LoadMoney> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserGuid).IsRequired();
            builder.Property(x => x.Balance).IsRequired();
        }
    }
}
