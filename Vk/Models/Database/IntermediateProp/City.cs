using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Database.IntermediateProp
{
    public class City
    {
        [Key]
        public long CityDatabaseId { get; set; }

        public int id { get; set; }
        public string title { get; set; }

        public City()
        {
        }

        public City(Models.Views.EntitiesVk.Response.City city)
        {
            id = city.id;
            title = city.title;
        }
    }
}