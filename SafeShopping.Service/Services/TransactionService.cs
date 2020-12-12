using SafeShopping.Core.DataAccess;
using SafeShopping.Core.Entitiy.Concrete;
using SafeShopping.Core.Service;
using SafeShopping.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.Service.Services
{
    public class TransactionService : Service.Services.Service<Transaction>, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public readonly IUnitOfWork _unitOfWork;

        public TransactionService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork) : base(unitOfWork, transactionRepository)
        {
            _transactionRepository = transactionRepository;

            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Transaction> GetTransactionWithUserId(string guid)
        {
            return _transactionRepository.GetTransactionWithUserId(guid);
        }
    }
}
