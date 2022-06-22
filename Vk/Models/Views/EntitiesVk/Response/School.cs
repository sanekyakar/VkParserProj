using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Views.EntitiesVk.Response
{
    public class School
    {
        public int city { get; set; }
        public string @class { get; set; } = string.Empty;
        public int country { get; set; }
        public string id { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public int type { get; set; }
        public string type_str { get; set; } = string.Empty;
        public int year_from { get; set; }
        public int year_graduated { get; set; }
        public int year_to { get; set; }
        public string speciality { get; set; } = string.Empty;
    }
}