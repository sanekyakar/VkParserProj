using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Views.EntitiesVk.Response
{
    public class University
    {
        public int chair { get; set; }
        public string chair_name { get; set; } = string.Empty;
        public int city { get; set; }
        public int country { get; set; }
        public string education_status { get; set; } = string.Empty;
        public int faculty { get; set; }
        public string faculty_name { get; set; } = string.Empty;
        public int graduation { get; set; }
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string education_form { get; set; } = string.Empty;
    }
}