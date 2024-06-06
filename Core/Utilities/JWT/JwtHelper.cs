using Core.Entities;
using Core.Utilities.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.JWT
{
    public class JwtHelper : ITokenHelper
    {
        //private readonly IConfiguration _configuration;
        //public JwtHelper(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        private readonly TokenOptions _tokenOptions;
        public JwtHelper(TokenOptions tokenOptions)
        {
            _tokenOptions = tokenOptions;
        }
        public AccessToken CreateToken(BaseUser user)
        {
            //TokenOptions tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();

            DateTime expirationTime = DateTime.Now.AddMinutes(_tokenOptions.ExpirationTime);
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: null,
                notBefore: DateTime.Now,
                expires: expirationTime,
                signingCredentials: signingCredentials
                );
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            string jwtToken = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken() { Token = jwtToken, ExpirationTime = expirationTime };
        }
        
    }
}
