using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Views
{
    public class UserAccount
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public Models.Database.UserAccount.Roles Roles { get; set; }
    }
}