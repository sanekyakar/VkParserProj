using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Database
{
    public class UserAccount
    {
        public long Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public List<VkEntities.GroupVkDatabase> Groups { get; set; }
        public Roles Role { get; set; }

        public enum Roles
        {
            Admin = 1,
            User,
        }
    }
}