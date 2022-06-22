using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Database.IntermediateProp
{
    public class LastSeen
    {
        [Key]
        public long LastSeenDatabaseId { get; set; }

        public int platform { get; set; }
        public int time { get; set; }

        public LastSeen()
        {
        }

        public LastSeen(Models.Views.EntitiesVk.Response.LastSeen lastSeen)
        {
            platform = lastSeen.platform;
            time = lastSeen.time;
        }
    }
}