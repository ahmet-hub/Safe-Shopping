using SafeShopping.Core.DataAccess;
using SafeShopping.Core.Entitiy;
using SafeShopping.Core.Entitiy.Concrete;
using SafeShopping.Core.Service;
using SafeShopping.Core.UnitOfWork;
using SafeShopping.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.Service.Services
{
    public class AccountService : Service.Services.Service<Account>, IAccountService
    {
        private readonly IAccountCheckService _accountCheckService;
        private readonly IEntityRepositoy<Account> _repositoy;
        public readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork, IEntityRepositoy<Account> repositoy,IAccountCheckService accountCheckService) : base(unitOfWork, repositoy)
        {
            _repositoy = repositoy;
            _unitOfWork = unitOfWork;
            _accountCheckService = accountCheckService;
        }

        public async Task<IEntity> AddWithMernisAuth(Account account)
        {
            if (_accountCheckService.CheckIfRealPerson(account))
            {
                await _repositoy.Add(account);
                await _unitOfWork.CommitAsync();
                return account;
            }
            else
            {
                throw new Exception("MERNIS");
            }
         
        }

      
    }
}
