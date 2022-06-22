using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vk.Models;
using Vk.Models.Error;
using Vk.Models.Views;

namespace Vk.Services
{
    public class UsersAccountServices
    {
        private ApplicationContext applicationcontext;

        public UsersAccountServices()
        {
            applicationcontext = new ApplicationContext();
        }

        public Models.Views.UserAccount CreateUser(UserAccount userView, out ApiErrorResult apiErrorResult)
        {
            apiErrorResult = default;

            var searchUser = applicationcontext.UserAccounts.FirstOrDefault(u => u.Login == userView.Login);
            if (searchUser != default)
            {
                apiErrorResult = new ApiErrorResult { GlobalError = "Пользователь с таким логином уже существует.\n Пожалуйста,введите другой логин" };
                return default;
            }
            var userDb = new Models.Database.UserAccount();
            userDb.Login = userView.Login;
            userDb.Password = userView.Password;
            userDb.Role = (Models.Database.UserAccount.Roles)2;
            applicationcontext.Add(userDb);
            applicationcontext.SaveChanges();

            var userViewModels = new Models.Views.UserAccount
            {
                Login = userDb.Login,
                Password = userDb.Password
            };
            return userViewModels;
        }
    }
}