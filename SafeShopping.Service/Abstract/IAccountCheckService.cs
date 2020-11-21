using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.Service.Abstract
{
    public interface IAccountCheckService
    {
        public bool CheckIfRealPerson(Account account);

    }
}
