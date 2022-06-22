using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Database.VkEntities
{
    public class GroupVkDatabase
    {
        [Key]
        public long DatabaseID { get; set; }

        public FriendsVk FriendsVk { get; set; }
        public int id { get; set; }

        public string description { get; set; } = string.Empty;
        public string activity { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public int wall { get; set; }
        public string name { get; set; } = string.Empty;
        public string screen_name { get; set; } = string.Empty;
        public int is_closed { get; set; }
        public string type { get; set; } = string.Empty;
        public string photo_50 { get; set; } = string.Empty;
        public string photo_100 { get; set; } = string.Empty;
        public string photo_200 { get; set; } = string.Empty;

        public List<Models.Database.VkEntities.Members> Members = new List<Members>();

        public GroupVkDatabase()
        {
        }

        public GroupVkDatabase(Models.Views.EntitiesVk.Response.GroupJson groupJson)
        {
            id = groupJson.id;
            description = groupJson.description;
            activity = groupJson.activity;
            status = groupJson.status;
            wall = groupJson.wall;
            name = groupJson.name;
            screen_name = groupJson.screen_name;
            is_closed = groupJson.is_closed;
            type = groupJson.type;
            photo_50 = groupJson.photo_50;
            photo_100 = groupJson.photo_100;
            photo_200 = groupJson.photo_200;
        }
    }
}