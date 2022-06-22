using Microsoft.EntityFrameworkCore;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vk.Models;
using Vk.Models.Database;
using Vk.Models.Error;

namespace Vk.Services
{
    public class VkAuthServices
    {
        private ApplicationContext context;

        public VkAuthServices()
        {
            context = new ApplicationContext();
        }

        public Uri GetToken(out ApiErrorResult apiErrorResult)
        {
            apiErrorResult = default;

            //Должно быть id приложения
            var idApp = "12345678";

            var redirectPath = "https://localhost:44394";

            var uri = $"https://oauth.vk.com/authorize?" +
                $"client_id={idApp}&display=page&redirect_uri={redirectPath}&" +
                $"scope=friends&response_type=token&v=5.131&state=123456";

            RestClient client = new RestClient(uri);

            var request = new RestRequest(uri, Method.Get);

            var response = client.GetAsync(request);
            if (response.Result == null)
            {
                apiErrorResult = new ApiErrorResult { GlobalError = "Пустой ответ с сервера" };
                return default;
            }
            if (response.Result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                apiErrorResult = new ApiErrorResult { GlobalError = "Ошибка в получении токена" };
                return default;
            }
            var result = response.Result.ResponseUri;

            return result;
        }

        public Models.Database.AuthTokenVk CreateToken(AuthTokenVk tokenVk, out ApiErrorResult apierrorResult)
        {
            apierrorResult = default;
            var checkToken = context.TokenVk.AsNoTracking().Where(f => f.Id != default)
                .FirstOrDefault(f => f.Id == 1);
            tokenVk.Id = 1;
            if (checkToken != default)
                context.TokenVk.Update(tokenVk);
            if (checkToken == default)
                context.TokenVk.Add(tokenVk);
            context.SaveChanges();

            return tokenVk;
        }
    }
}