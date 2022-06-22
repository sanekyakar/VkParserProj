using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Vk.Models;
using Vk.Models.Error;
using Vk.Models.Views;

using Microsoft.AspNetCore.Mvc;

namespace Vk.Controllers
{
    /// <summary>
    /// Роут для получния токена нашего приложения
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class Authorization : Controller
    {
        [HttpPost("AutorizeToken")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Views.UserAccount))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Models.Error.ApiErrorResult))]
        public IActionResult Token([Required][FromBody] Models.Views.UserAccount user)
        {
            var identity = GetIdentity(user.Login, user.Password, out Models.Database.UserAccount userAccountDB);

            if (identity == null)
                return BadRequest(new ApiErrorResult() { GlobalError = "Неправильный логин-пароль" });

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromHours(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var userTokenResponse = new UserTokenResponse
            {
                token = new JwtSecurityTokenHandler().WriteToken(jwt),
                Login = identity.Name
            };
            Models.Views.UserAccount userView = new Models.Views.UserAccount { Login = userAccountDB.Login, Roles = userAccountDB.Role };

            if (userAccountDB != default)
                Models.Account.Users.Add(
                    userView, userTokenResponse);

            return Json(userTokenResponse);
        }

        private ClaimsIdentity GetIdentity(string login, string password, out Models.Database.UserAccount userAccount)
        {
            using var context = new ApplicationContext();

            userAccount = context.UserAccounts.FirstOrDefault(x => x.Login == login && x.Password == password);

            if (userAccount != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userAccount.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, userAccount.Role.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}