using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Views.EntitiesVk.Response
{
    public class GroupJson
    {
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
    }
}