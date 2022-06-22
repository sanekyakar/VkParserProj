using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Database.IntermediateProp
{
    public class School
    {
        [Key]
        public long SchoolDatabaseId { get; set; }

        public Models.Database.VkEntities.GroupVkDatabase GroupVkDatabase { get; set; }
        public int city { get; set; }
        public string @class { get; set; }
        public int country { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public string type_str { get; set; }
        public int year_from { get; set; }
        public int year_graduated { get; set; }
        public int year_to { get; set; }
        public string speciality { get; set; }

        public School()
        {
        }

        public School(Models.Views.EntitiesVk.Response.School school)
        {
            city = school.city;
            @class = school.@class;
            country = school.country;
            id = school.id;
            name = school.name;
            type = school.type;
            type_str = school.type_str;
            year_from = school.year_from;
            year_graduated = school.year_graduated;
            year_to = school.year_to;
            speciality = school.speciality;
        }
    }
}