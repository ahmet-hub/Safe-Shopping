using Microsoft.EntityFrameworkCore;
using SafeShopping.Core.Entitiy.Concrete;
using SafeShopping.DataAccess.EntityFramework.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.DataAccess.EntityFramework
{
    public class SafeShoppingContext:DbContext
    {
        public SafeShoppingContext(DbContextOptions<SafeShoppingContext> options) : base(options)
        {
         
            
        }

        public DbSet<Account> Accounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
        }

    }
}
