using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeShopping.Service.Responses
{
    public class UserResponse : BaseResponse
    {
        public User User { get; set; }


        private UserResponse(bool success, string message, User user) : base(success, message)
        {
            this.Message = message;
            this.Success = success;
            this.User = user;

        }

        public UserResponse(User user) : this(true, string.Empty, user)
        {

        }

        public UserResponse(string message) : this(false, message, null)
        {


        }






    }
}
