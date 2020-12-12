using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.Core.Service
{
    public interface ITransactionService:IService<Transaction>
    {
        public IEnumerable<Transaction> GetTransactionWithUserId(string guid);
    }
}
