using SafeShopping.Service.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.Service.Services.Authentication
{
    public interface IAuthenticationService
    {
        AccessTokenResponse CreateAccessToken(string email, string password);
        AccessTokenResponse CreateAccessTokenByRefreshToken(string refreshToken);
        AccessTokenResponse RevokeRefreshToken(string refreshToken);
    }
}
