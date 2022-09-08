using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace EMarket.Helper
{
    public static class TokenManager
    {
        public static string GetToken(string userRoles, string userName, JWTConfig jWTConfig)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
            if (userRoles != null && userRoles!=null)
            {
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole.ToString()));
                }
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jWTConfig.Secret));

            var token = new JwtSecurityToken(
                issuer: jWTConfig.Authority,
                audience: jWTConfig.Audience,
                //expires: DateTime.Now.AddMinutes(1),
                expires: DateTime.Now.AddHours(jWTConfig.Expires),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public static string GetToken(IList<string> userRoles, string userName, JWTConfig jWTConfig)
        //{
        //    var authClaims = new List<Claim>
        //        {
        //            new Claim(ClaimTypes.Name, userName),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //        };
        //    if(userRoles != null && userRoles.Count > 0)
        //    {
        //        foreach (var userRole in userRoles)
        //        {
        //            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        //        }
        //    }

        //    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jWTConfig.Secret));

        //    var token = new JwtSecurityToken(
        //        issuer: jWTConfig.Authority,
        //        audience: jWTConfig.Audience,
        //        expires: DateTime.Now.AddHours(jWTConfig.Expires),
        //        claims: authClaims,
        //        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        //        );

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        public static string GetHash(string password)
        {
          
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Get the hashed string.  
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public static string getPassword()
        {
            Random rnd = new Random();
            return "Pass@" + rnd.Next(100, 999);
        }
    }
}
