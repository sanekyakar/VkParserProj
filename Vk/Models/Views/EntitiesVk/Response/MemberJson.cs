using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Views.EntitiesVk.Response
{
    public class MemberJson
    {
        public int count { get; set; }

        public List<Members> items { get; set; }
    }
}