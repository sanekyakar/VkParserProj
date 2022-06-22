using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Views.EntitiesVk
{
    /// <summary>
    /// Класс описывающий группу
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Id группы
        /// </summary>
        public string group_ids { get; set; }

        public string group_id { get; set; }

        public string fields { get; set; } = "activity,type,description,status,wall";
    }
}