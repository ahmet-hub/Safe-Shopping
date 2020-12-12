using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SafeShopping.Core.DataAccess
{
    public interface IUserRepository : IEntityRepositoy<User>
    {
        public void SafeRefreshToken(int userId, string refreshToken);
        public void RemoveRefreshToken(User user);
        public Task<User> FindByEmailAndPassword(string email, string password);
        public Task<User> GetUserWithRefreshToken(string refreshToken);
        public Task<User> GetUserWithGuidId(string guid);
        public void AddMoney(int id, decimal balance);
        public void RemoveMoney(int id, decimal balance);

    }
}
