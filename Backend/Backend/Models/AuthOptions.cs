﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Backend.Models
{
        public class AuthOptions
        {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        //    public const string ISSUER = "MyAuthServer"; // издатель токена
        //    public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        //    //const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        //    public const int LIFETIME = 1; // время жизни токена - 1 минута
        //public static SecurityKey SigningKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes("20522"));
        //internal static string GenerateToken(bool is_admin = false)
        //{
        //    var now = DateTime.UtcNow;
        //    var claims = new List<Claim>
        //        {
        //            new Claim(ClaimsIdentity.DefaultNameClaimType, "user"),
        //            new Claim(ClaimsIdentity.DefaultRoleClaimType, is_admin?"admin":"guest")
        //        };
        //    ClaimsIdentity identity =
        //    new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
        //        ClaimsIdentity.DefaultRoleClaimType);
        //    // создаем JWT-токен
        //    var jwt = new JwtSecurityToken(
        //            issuer: ISSUER,
        //            audience: AUDIENCE,
        //            notBefore: now,
        //            expires: now.AddYears(LIFETIME),
        //            claims: identity.Claims,
        //            signingCredentials: new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256)); ;
        //    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        //    return encodedJwt;
        //}
    }
    
}
