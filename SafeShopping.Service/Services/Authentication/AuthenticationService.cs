using SafeShopping.Core.Service;
using SafeShopping.Service.Responses;
using SafeShopping.Service.Security.Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace SafeShopping.Service.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly ITokenHandle _tokenHandle;

        public AuthenticationService(IUserService userService, ITokenHandle tokenHandle)
        {
            _userService = userService;
            _tokenHandle = tokenHandle;
        }
        public AccessTokenResponse CreateAccessToken(string email, string password)
        {
            var user = _userService.FindByEmailAndPassword(email, password).Result;
            UserResponse userResponse = new UserResponse(user);

            if (userResponse.Success)
            {
                AccessToken accessToken = _tokenHandle.CreateAccessToken(userResponse.User);
                _userService.SaveRefreshToken(userResponse.User.Id, accessToken.RefreshToken);

                return new AccessTokenResponse(accessToken);
            }
            else
            {
                return new AccessTokenResponse(userResponse.Message);
            }
        }

        public AccessTokenResponse CreateAccessTokenByRefreshToken(string refreshToken)
        {
            var user = _userService.GetUserWithRefreshToken(refreshToken).Result;
            UserResponse userResponse = new UserResponse(user);

            if (userResponse.Success)
            {

                if (userResponse.User.RefreshTokenEndDate > DateTime.Now)
                {
                    AccessToken accessToken = _tokenHandle.CreateAccessToken(userResponse.User);
                    _userService.SaveRefreshToken(userResponse.User.Id, accessToken.RefreshToken);
                    return new AccessTokenResponse(accessToken);

                }

                else
                {
                    return new AccessTokenResponse("Refresh token suresi doldu.");
                }

            }

            else
            {
                return new AccessTokenResponse("RefreshToken bulunamadi.");
            }
        }

        public AccessTokenResponse RevokeRefreshToken(string refreshToken)
        {
            var user = _userService.GetUserWithRefreshToken(refreshToken).Result;

            UserResponse userResponse = new UserResponse(user);

            if (userResponse.Success)
            {

                _userService.RemoveRefreshToken(userResponse.User);

                return new AccessTokenResponse(new AccessToken());

            }
            else
            {
                return new AccessTokenResponse("Refresh Token Bulunamadi.");
            }
        }
    }
}
