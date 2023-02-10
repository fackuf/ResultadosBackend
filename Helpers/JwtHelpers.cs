using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ResultadosBackend.Models;

namespace ResultadosBackend.Helpers
{
    public static class JwtHelpers
    {
        public static IEnumerable<Claim> GetClaims(this UserToken userAccounts, Guid Id)
        {
            List<Claim> claims = new List<Claim>()
            {

                new Claim("Id",userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Name, userAccounts.UserName),
                new Claim(ClaimTypes.Email, userAccounts.Email),
                new Claim(ClaimTypes.NameIdentifier, userAccounts.Id.ToString()),
                new Claim(ClaimTypes.Expiration,DateTime.UtcNow.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))

            };
            if (userAccounts.UserName == "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "Administrador"));
            }
            else if (userAccounts.UserName != "Admin")
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
                claims.Add(new Claim("UserOnly", "User 1"));
            }
            return claims;

        }

        public static IEnumerable<Claim> GetClaims(this UserToken userAccounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return GetClaims(userAccounts, Id);

        }

        public static UserToken GenTokenKey(UserToken model, JwtSetting JwtSettings)
        {
            try
            {
                var userToken = new UserToken();
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }
                // Obtain SecretKey
                var key = System.Text.Encoding.ASCII.GetBytes(JwtSettings.IssuerSigningKey);
                Guid Id;
                //Expires in one Day
                DateTime expireTime = DateTime.UtcNow.AddDays(1);
                // Validity of token
                userToken.Validity = expireTime.TimeOfDay;

                //Generate JWT
                var jwToken = new JwtSecurityToken(
                    issuer: JwtSettings.ValidIssuer,
                    audience: JwtSettings.ValidAudience,
                    claims: GetClaims(model, out Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expireTime).DateTime,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256));

                // Generate USERTOKEN
                userToken.Token = new JwtSecurityTokenHandler().WriteToken(jwToken);
                userToken.UserName = model.UserName;
                userToken.Id = model.Id;
                userToken.GuidId = Id;
                return userToken;

            }
            catch (Exception exception)
            {
                throw new Exception("ERROR JWT", exception);
            }
        }
    }
}
