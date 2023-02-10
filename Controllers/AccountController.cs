using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResultadosBackend.DataAccess;
using ResultadosBackend.Helpers;
using ResultadosBackend.Models;
using System.Data;

namespace ResultadosBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSetting _JwtSettings;
        public AccountController(JwtSetting JwtSettings)
        {
            _JwtSettings = JwtSettings;
        }

        private IEnumerable<User> Logins = new List<User>()
        {
            new User()
            {
                Id= 1,
                email= "qqwwardr@email.com",
                username= "Admin",
                password= "Admin"
            },
            new User()
            {
                Id= 2,
                email= "qeqwq@email.com",
                username= "User1",
                password= "asd"
            },

        };

        [HttpPost]
        public IActionResult GetToken(UserLogin userLogin)
        {
            try
            {
                var Token = new UserToken();
                var Valid = Logins.Any(user => user.username.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                if (Valid)
                {
                    var user = Logins.FirstOrDefault(user => user.username.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));

                    Token = JwtHelpers.GenTokenKey(new UserToken()
                    {
                        UserName = user.username,
                        Email = user.email,
                        Id = user.Id,
                        GuidId = Guid.NewGuid(),

                    }, _JwtSettings);
                }
                else
                {
                    return BadRequest(" Wrong Password");
                }
                return Ok(Token);
            }
            catch (Exception ex)
            {
                throw new Exception("Get Token ERROR ", ex);
            }
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }

    }
}
