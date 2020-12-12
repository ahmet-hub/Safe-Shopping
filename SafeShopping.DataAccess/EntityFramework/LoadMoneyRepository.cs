using SafeShopping.Core.DataAccess;
using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.DataAccess.EntityFramework
{
    public class LoadMoneyRepository : EfEntityRepositoryBase<LoadMoney>, ILoadMoneyRepository
    {
        public SafeShoppingContext _safeShoppingContext { get => _dbContext as SafeShoppingContext; }

        public LoadMoneyRepository(SafeShoppingContext context) : base(context)
        {

        }
    }
}
