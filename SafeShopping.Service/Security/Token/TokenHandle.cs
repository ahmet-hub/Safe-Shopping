using Microsoft.IdentityModel.Tokens;
using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SafeShopping.Service.Security.Token
{
    public class TokenHandle : ITokenHandle
    {
        public AccessToken CreateAccessToken(User user)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(10);
            var securityKey = SignHandle.GetSecurityKey("mysecuritykeymysecuritykeymysecuritykeyahmet");

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(

                audience: "www.safeshopping.com",
                issuer: "www.safeshopping.com",
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetClaims(user),
                signingCredentials: signingCredentials

                );

            var handle = new JwtSecurityTokenHandler();
            var token = handle.WriteToken(jwtSecurityToken);
            AccessToken accessToken = new AccessToken();
            accessToken.Token = token;
            accessToken.Expiration = accessTokenExpiration;
            accessToken.RefreshToken = CreateRefreshToken();
            return accessToken;

        }
        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
           {

               new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
               new Claim(ClaimTypes.Email,user.Email),
               new Claim(ClaimTypes.Name,user.Name)


           };

            return claims;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(numberByte);
                return Convert.ToBase64String(numberByte);

            }
        }
        public void RevokeRefreshToken(User user)
        {
            user.RefreshToken = null;
        }
    }
}
