using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vk.Models.Error;

namespace Vk.Controllers.VkControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupControllers : Controller
    {
        [HttpPost("GetInfoGroups")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Views.EntitiesVk.Group))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Models.Error.ApiErrorResult))]
        [Authorize]
        public IActionResult GetInfoGroups(Models.Views.EntitiesVk.Group group)
        {
            if (string.IsNullOrWhiteSpace(group.group_id))
                return BadRequest(new ApiErrorResult { GlobalError = "Введите id группы" });

            var result = new Services.GroupServices().GetInfoGroups(group, out ApiErrorResult apiErrorResult);
            if (apiErrorResult != default)
                return BadRequest(apiErrorResult);

            return Json(result);
        }

        [Authorize]
        [HttpGet("GetGroups")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Database.VkEntities.GroupVkDatabase))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiErrorResult))]
        public IActionResult GetGroupsInfo()
        {
            return Json(new Services.GroupServices().Get());
        }

        [HttpPost("GetMembers")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Models.Views.EntitiesVk.Group))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Models.Error.ApiErrorResult))]
        [Authorize]
        public IActionResult GetMembers(Models.Views.EntitiesVk.GetMember getMember)
        {
            if (getMember.group_id == null)
                return BadRequest(new ApiErrorResult { GlobalError = "Отсутсвует id группы" });

            var result = new Services.GroupServices().GetMembers(getMember, out ApiErrorResult apiErrorResult);
            if (apiErrorResult != default)
                return BadRequest(apiErrorResult);

            return Json(result);
        }

        [HttpPost("GetFriends")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Models.Error.ApiErrorResult))]
        [Authorize]
        public IActionResult GetFriends(Models.Views.EntitiesVk.Friends friends)
        {
            //if (friends.user_id == default || friends.offset == default || friends.count == default)
            //    return BadRequest(new ApiErrorResult { GlobalError = "Введите обязательные параметры" });
            if (friends == null)
                return BadRequest(new ApiErrorResult { GlobalError = "Отсутсвуют данные для получения друзей" });

            var result = new Services.GroupServices().GetFriends(friends, out ApiErrorResult apiErrorResult);

            if (apiErrorResult != default)
                return BadRequest(apiErrorResult);
            return Json(result);
        }

        [HttpPost("GetGroupFriends")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Models.Error.ApiErrorResult))]
        [Authorize]
        public IActionResult GetGoupsFrineds(Models.Views.EntitiesVk.GetFriendsGroup getGoupsById)
        {
            //if (getGoupsById.user_id == default)
            //    return BadRequest(new ApiErrorResult { GlobalError = "Укажите id пользователя" });
            var result = new Services.GroupServices().GetGroupsFriends(getGoupsById, out ApiErrorResult apiErrorResult);

            return Json(result);
        }

        [HttpPost("GetRange")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Models.Error.ApiErrorResult))]
        public IActionResult GetFriends(Models.Views.GetRangeUsers getRangeUsers)
        {
            //if (getRangeUsers.All != default && getRangeUsers.RangeMax != default || getRangeUsers.RangeMin != default)
            //    return BadRequest("Выберите корретный тип выборки (вы выбрали все типы одновременно)");

            if (getRangeUsers.RangeMax != default && getRangeUsers.RangeMin == default)
                return BadRequest("Не указан минимальнальный параметр выборки");
            if (getRangeUsers.RangeMin != default && getRangeUsers.RangeMax == default)
                return BadRequest("Не указан максиммальный параметр выборки");
            if (getRangeUsers == default)
                return BadRequest("Пустой объект");
            if (getRangeUsers.RangeMax == default && getRangeUsers.RangeMin == default)
                return BadRequest("Введите параметры ранжирования");

            var result = new Services.GroupServices().GetUsers(getRangeUsers, out ApiErrorResult apiErrorResult);

            return Json(result);
        }

        [HttpPost("RangeFriendsMembersGroups")]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Models.Error.ApiErrorResult))]
        public IActionResult RangeRoups(Models.Views.GetRangeUsers getRangeUsers)
        {
            //if (getRangeUsers.All != default && getRangeUsers.RangeMax != default || getRangeUsers.RangeMin != default)
            //    return BadRequest("Выберите корретный тип выборки (вы выбрали все типы одновременно)");

            if (getRangeUsers.RangeMax != default && getRangeUsers.RangeMin == default)
                return BadRequest("Не указан минимальнальный параметр выборки");
            if (getRangeUsers.RangeMin != default && getRangeUsers.RangeMax == default)
                return BadRequest("Не указан максиммальный параметр выборки");
            if (getRangeUsers == default)
                return BadRequest("Пустой объект");
            if (getRangeUsers.RangeMax == default && getRangeUsers.RangeMin == default)
                return BadRequest("Введите параметры ранжирования");

            var result = new Services.GroupServices().GetUsers(getRangeUsers, out ApiErrorResult apiErrorResult);

            return Json(result);
        }

        [HttpGet("RangeFriendsCount")]
        public IActionResult RangeFriendscount()
        {
            var result = new Services.GroupServices().GetUsersCountFriends(out ApiErrorResult apiErrorResult);

            return Json(result);
        }
    }
}