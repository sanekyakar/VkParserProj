using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Database.IntermediateProp
{
    public class University
    {
        [Key]
        public long UniversityDatabaseId { get; set; }

        public Models.Database.VkEntities.GroupVkDatabase GroupVkDatabase { get; set; }
        public int chair { get; set; }
        public string chair_name { get; set; }
        public int city { get; set; }
        public int country { get; set; }
        public string education_status { get; set; }
        public int faculty { get; set; }
        public string faculty_name { get; set; }
        public int graduation { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string education_form { get; set; }

        public University()
        {
        }

        public University(Models.Views.EntitiesVk.Response.University university)
        {
            chair = university.chair;
            chair_name = university.chair_name;
            city = university.city;
            country = university.country;
            education_status = university.education_status;
            faculty = university.faculty;
            faculty_name = university.faculty_name;
            graduation = university.graduation;
            id = university.id;
            name = university.name;
            education_form = university.education_form;
        }

        //public University(List<Models.Views.EntitiesVk.Response.University> university)
        //{
        //    chair = university.chair;
        //    chair_name = university.chair_name;
        //    city = university.city;
        //    country = university.country;
        //    education_status = university.education_status;
        //    faculty = university.faculty;
        //    faculty_name = university.faculty_name;
        //    graduation = university.graduation;
        //    id = university.id;
        //    name = university.name;
        //    education_form = university.education_form;
        //}
    }
}