using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Views.EntitiesVk.Response
{
    public class FriendsResponseIntermedia
    {
        public int count { get; set; }

        public List<Friends> items { get; set; }
    }
}