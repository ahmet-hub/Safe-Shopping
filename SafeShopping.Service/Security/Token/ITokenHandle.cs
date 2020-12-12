using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.Service.Security.Token
{
    public interface ITokenHandle
    {
        AccessToken CreateAccessToken(User user);
        void RevokeRefreshToken(User user);



    }
}
