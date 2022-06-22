using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Database.IntermediateProp
{
    public class Relative
    {
        [Key]
        public long RelativeDatabaseId { get; set; }

        public Models.Database.VkEntities.GroupVkDatabase GroupVkDatabase { get; set; }
        public string type { get; set; }
        public int id { get; set; }
        public string name { get; set; }

        public Relative()
        {
        }

        public Relative(Models.Views.EntitiesVk.Response.Relative relative)
        {
            type = relative.type;
            id = relative.id;
            name = relative.name;
        }
    }
}