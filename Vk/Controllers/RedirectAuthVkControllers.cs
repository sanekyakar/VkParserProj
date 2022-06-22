using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vk.Models.Error;

namespace Vk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedirectAuthVkControllers : Controller
    {
        [Authorize]
        [HttpGet("GetRedirectUri")]
        public IActionResult GetToken()
        {
            var user = User.Identities.FirstOrDefault();
            if (user == default)
                return BadRequest(new ApiErrorResult { GlobalError = "Имя пользователя не найдено" });

            var token = new Services.VkAuthServices().GetToken(out ApiErrorResult api);

            return Json(token);
        }

        [Authorize]
        [HttpPost("AddTokeDB")]
        public IActionResult CreateToken(Models.Database.AuthTokenVk tokenVk)
        {
            if (tokenVk.TokenValue == null || tokenVk.TokenValue == string.Empty)
                return BadRequest(new ApiErrorResult { GlobalError = "Отсутсвует токен" });

            var token = new Services.VkAuthServices().CreateToken(tokenVk, out ApiErrorResult apierrorResult);

            return Json(token);
        }
    }
}