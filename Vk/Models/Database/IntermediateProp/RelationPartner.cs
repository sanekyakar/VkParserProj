using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Database.IntermediateProp
{
    public class RelationPartner
    {
        [Key]
        public long RelationPartnerDatabaseId { get; set; }

        public Models.Database.VkEntities.GroupVkDatabase GroupVkDatabase { get; set; }
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        public RelationPartner()
        {
        }

        public RelationPartner(Models.Views.EntitiesVk.Response.RelationPartner relationPartner)
        {
            id = relationPartner.id;
            first_name = relationPartner.first_name;
            last_name = relationPartner.last_name;
        }
    }
}