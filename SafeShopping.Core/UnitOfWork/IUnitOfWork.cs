using SafeShopping.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAccountRepository Account { get; }
        Task CommitAsync();
        void Commit();
    }
}
