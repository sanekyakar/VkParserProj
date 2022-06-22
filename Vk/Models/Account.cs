using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models
{
    public class Account
    {
        public static Dictionary<Models.Views.UserAccount, Models.Views.UserTokenResponse> Users { get; set; } = new();
    }
}