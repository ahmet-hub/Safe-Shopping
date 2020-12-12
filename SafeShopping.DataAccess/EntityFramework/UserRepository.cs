using Microsoft.EntityFrameworkCore;
using SafeShopping.Core.DataAccess;
using SafeShopping.Core.Entitiy;
using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.DataAccess.EntityFramework
{
    public class UserRepository : EfEntityRepositoryBase<User>, IUserRepository
    {
        public SafeShoppingContext _safeShoppingContext { get => _dbContext as SafeShoppingContext; }

        public UserRepository(SafeShoppingContext context) : base(context)
        {

        }

        public void SafeRefreshToken(int userId, string refreshToken)
        {
            var user = base.GetByIdAsync(userId).Result;

            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate = DateTime.Now.AddDays(10);

        }

        public void RemoveRefreshToken(User user)
        {
            var removeUser = base.GetByIdAsync(user.Id).Result;

            removeUser.RefreshToken = null;

        }

        public Task<User> FindByEmailAndPassword(string email, string password)
        {
            return _dbSet.SingleOrDefaultAsync(u => u.Email == email && u.Password == password);

        }

        public Task<User> GetUserWithRefreshToken(string refreshToken)
        {
            return _dbSet.SingleOrDefaultAsync(u => u.RefreshToken == refreshToken);
        }

        public Task<User> GetUserWithGuidId(string guid)
        {
            return _dbSet.SingleOrDefaultAsync(u => u.Guid == guid);

        }
        public void AddMoney(int id, decimal balance)
        {
            var result = base.GetByIdAsync(id).Result;
            result.Balance += balance;

        }
        public void RemoveMoney(int id, decimal balance)
        {
            var result = base.GetByIdAsync(id).Result;
            result.Balance -= balance;
        }
    }
}
