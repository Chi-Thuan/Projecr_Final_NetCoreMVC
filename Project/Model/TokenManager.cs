using Microsoft.IdentityModel.Tokens;
using Project.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Project
{
    public class TokenManager
    {
        public static string secrect = "qweyuiopasdfghjklzxcvbnm";

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                if (jwtToken == null) return null;
                byte[] key = Convert.FromBase64String(secrect);
                TokenValidationParameters parameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;

                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken);
                return principal;
            }
            catch
            {
                return null;
            }
        }

        public static UserToken ValidateToken(string token)
        {
            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null) return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }

            Claim id = identity.FindFirst("ID");
            Claim fullname = identity.FindFirst("FULLNAME");
            Claim email = identity.FindFirst("EMAIL");
            Claim role = identity.FindFirst("ROLE");
            UserToken user = new UserToken();
            user.id = id.Value;
            user.fullname = fullname.Value;
            user.email = email.Value;
            user.role = Int32.Parse(role.Value);
            return user;
        }
    }
}