using SafeShopping.Core.DataAccess;
using SafeShopping.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.DataAccess.EntityFramework.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserRepository _accountRepository;

        private TransactionRepository _transactionRepository;
        public IUserRepository User => _accountRepository ??= new UserRepository(_safeShoppingContext);
        public ITransactionRepository Transaction => _transactionRepository ??= new TransactionRepository(_safeShoppingContext);

        private readonly SafeShoppingContext _safeShoppingContext;
        public UnitOfWork(SafeShoppingContext context)
        {

            _safeShoppingContext = context;

        }

        public void Commit()
        {
            _safeShoppingContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _safeShoppingContext.SaveChangesAsync();
        }
    }
}
