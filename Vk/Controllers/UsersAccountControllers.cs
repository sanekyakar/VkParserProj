using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vk.Models.Error;

namespace Vk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAccountControllers : Controller
    {
        [HttpPost("Registration")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Views.UserAccount))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Models.Error.ApiErrorResult))]
        public IActionResult CreateUser(Models.Views.UserAccount user)
        {
            if (user == null)
                return BadRequest(new ApiErrorResult { GlobalError = "Пользователь пустой" });

            var result = new Services.UsersAccountServices().CreateUser(user, out ApiErrorResult apiErrorResult);

            if (apiErrorResult != default)
                return BadRequest(apiErrorResult);

            if (user.Login == string.Empty || user.Login == null)
                return BadRequest(new ApiErrorResult { GlobalError = "Ошибка при регистрации .\n Укажите лоигн" });

            if (user.Password == string.Empty || user.Login == null)
                return BadRequest(new ApiErrorResult { GlobalError = "Ошибка при регистрации .\n Укажите лоигн" });

            return Json(result);
        }
    }
}