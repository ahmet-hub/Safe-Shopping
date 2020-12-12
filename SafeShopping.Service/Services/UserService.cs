using SafeShopping.Core.DataAccess;
using SafeShopping.Core.Entitiy;
using SafeShopping.Core.Entitiy.Concrete;
using SafeShopping.Core.Service;
using SafeShopping.Core.UnitOfWork;
using SafeShopping.Service.Abstract;
using SafeShopping.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.Service.Services
{
    public class UserService : Service.Services.Service<User>, IUserService
    {
        private readonly IUserCheckService _userCheckService;
        private readonly IUserRepository _userRepository;
        public readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork, IUserRepository repositoy, IUserCheckService accountCheckService) : base(unitOfWork, repositoy)
        {
            _userRepository = repositoy;
            _unitOfWork = unitOfWork;
            _userCheckService = accountCheckService;
        }

        public async Task<IEntity> AddWithMernisAuth(User user)
        {
            if (_userCheckService.CheckIfRealPerson(user))
            {
                await _userRepository.Add(user);
                await _unitOfWork.CommitAsync();
                return user;
            }
            else
            {
                throw new Exception("MERNIS");
            }

        }

        public void SaveRefreshToken(int userId, string refreshToken)
        {


            _userRepository.SafeRefreshToken(userId, refreshToken);
            _unitOfWork.Commit();

        }

        public void RemoveRefreshToken(User user)
        {
            _userRepository.RemoveRefreshToken(user);
            _unitOfWork.Commit();
        }

        public Task<User> FindByEmailAndPassword(string email, string password)
        {
            return _userRepository.FindByEmailAndPassword(email, password);
        }

        public Task<User> GetUserWithRefreshToken(string refreshToken)
        {
            return _userRepository.GetUserWithRefreshToken(refreshToken);
        }

        public Task<User> GetUserWithGuidId(string guid)
        {
            return _userRepository.GetUserWithGuidId(guid);
        }

        public void AddMoney(int id, decimal balance)
        {
            _userRepository.AddMoney(id, balance);
            _unitOfWork.Commit();
        }

        public void RemoveMoney(int id, decimal balance)
        {
            _userRepository.RemoveMoney(id, balance);
            _unitOfWork.Commit();
        }

    }
}
