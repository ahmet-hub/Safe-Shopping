using Microsoft.EntityFrameworkCore;
using SafeShopping.Core.Entitiy.Concrete;
using SafeShopping.DataAccess.EntityFramework.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.DataAccess.EntityFramework
{
    public class SafeShoppingContext : DbContext
    {
        public SafeShoppingContext(DbContextOptions<SafeShoppingContext> options) : base(options)
        {


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<LoadMoney> LoadMoneys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new LoadMoneyConfiguration());
        }

    }
}
