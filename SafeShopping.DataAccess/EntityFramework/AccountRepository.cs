using Microsoft.EntityFrameworkCore;
using SafeShopping.Core.DataAccess;
using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.DataAccess.EntityFramework
{
    public class AccountRepository:EfEntityRepositoryBase<Account>,IAccountRepository
    {

       public SafeShoppingContext _safeShoppingContext { get => _dbContext as SafeShoppingContext; }

        public AccountRepository(SafeShoppingContext context) : base(context)
        {

        }


    }
}
