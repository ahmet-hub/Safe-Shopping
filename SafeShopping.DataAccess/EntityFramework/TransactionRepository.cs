using Microsoft.EntityFrameworkCore;
using SafeShopping.Core.DataAccess;
using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.DataAccess.EntityFramework
{
    public class TransactionRepository : EfEntityRepositoryBase<Transaction>, ITransactionRepository
    {
        public SafeShoppingContext _safeShoppingContext { get => _dbContext as SafeShoppingContext; }

        public TransactionRepository(SafeShoppingContext context) : base(context)
        {

        }

        public IEnumerable<Transaction> GetTransactionWithUserId(string guid)
        {

            var data = base.GetAllAsync().Result.Where(t => t.SenderGuid == guid);
            return data;
            
        }
    }
}
