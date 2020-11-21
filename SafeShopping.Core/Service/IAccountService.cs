using SafeShopping.Core.Entitiy;
using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.Core.Service
{
    public interface IAccountService:IService<Account>
    {      
        Task<IEntity> AddWithMernisAuth(Account account);
    }
}
