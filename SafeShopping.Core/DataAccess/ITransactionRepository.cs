using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.Core.DataAccess
{
    public interface ITransactionRepository : IEntityRepositoy<Transaction>
    {
        public IEnumerable<Transaction> GetTransactionWithUserId(string guid);

    }
}
