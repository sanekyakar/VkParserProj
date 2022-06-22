using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Views
{
    public class UserTokenResponse
    {
        public string Login { get; set; }

        /// <summary>
        /// Токен
        /// </summary>
        public string token { get; set; }

        public Models.Database.UserAccount.Roles Roles { get; set; }
    }
}