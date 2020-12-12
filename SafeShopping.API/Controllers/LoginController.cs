using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeShopping.API.Resource;
using SafeShopping.Service.Responses;
using SafeShopping.Service.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeShopping.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IAuthenticationService _authenticationService;

        public LoginController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public IActionResult AccesToken(LoginResource loginResource)
        {
            AccessTokenResponse accessTokenResponse = _authenticationService.CreateAccessToken(loginResource.Email, loginResource.Password);

            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.AccessToken);
            }
            else
            {
                return BadRequest(accessTokenResponse.Message);
            }

        }

        [HttpPost]
        public IActionResult RefreshToken(TokenResource tokenResource)
        {

            AccessTokenResponse accessTokenResponse = _authenticationService.CreateAccessTokenByRefreshToken(tokenResource.RefreshToken);

            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.AccessToken);
            }

            else
            {
                return BadRequest(accessTokenResponse.Message);
            }

        }
        [HttpPost]
        public IActionResult RevokeRefreshToken(TokenResource tokenResource)
        {

            AccessTokenResponse accessTokenResponse = _authenticationService.RevokeRefreshToken(tokenResource.RefreshToken);

            if (accessTokenResponse.Success)
            {
                return Ok(accessTokenResponse.AccessToken);
            }
            else
            {
                return BadRequest(accessTokenResponse.Message);
            }

        }
    }
}
