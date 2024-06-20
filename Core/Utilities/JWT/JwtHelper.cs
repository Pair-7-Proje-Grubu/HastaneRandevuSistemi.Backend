using Core.Entities;
using Core.Utilities.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
        public AccessToken CreateToken(BaseUser user, List<BaseOperationClaim> operationClaims)
        {
            //TokenOptions tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();

            DateTime expirationTime = DateTime.Now.AddMinutes(_tokenOptions.ExpirationTime);
            SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: SetAllClaims(user, operationClaims.Select(o => o.Name).ToList()),
                notBefore: DateTime.Now,
                expires: expirationTime,
                signingCredentials: signingCredentials
                );
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            string jwtToken = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken() { Token = jwtToken, ExpirationTime = expirationTime };
        }

        protected IEnumerable<Claim> SetAllClaims(BaseUser user, List<string> operationClaims)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            //claims.Add(new Claim(ClaimTypes.Role, "Doctor"));

            foreach (var operationClaim in operationClaims)
            {
                claims.Add(new Claim(ClaimTypes.Role, operationClaim));
            }

            claims.Add(new Claim("Tobeto", "abc"));

            return claims;
        }
    }
}
