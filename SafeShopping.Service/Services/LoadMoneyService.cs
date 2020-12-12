using SafeShopping.Core.DataAccess;
using SafeShopping.Core.Entitiy.Concrete;
using SafeShopping.Core.Service;
using SafeShopping.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.Service.Services
{
    public class LoadMoneyService : Service<LoadMoney>, ILoadMoneyService
    {
        private readonly IEntityRepositoy<LoadMoney> _repositoy;
        public readonly IUnitOfWork _unitOfWork;

        public LoadMoneyService(IEntityRepositoy<LoadMoney> repositoy, IUnitOfWork unitOfWork) : base(unitOfWork, repositoy)
        {
            _repositoy = repositoy;
            _unitOfWork = unitOfWork;
        }

    }
}
