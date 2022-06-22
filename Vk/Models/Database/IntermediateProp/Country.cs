using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Database.IntermediateProp
{
    public class Country
    {
        [Key]
        public long CountryDatabaseId { get; set; }

        public int id { get; set; }
        public string title { get; set; }

        public Country()
        {
        }

        public Country(Models.Views.EntitiesVk.Response.Country country)
        {
            id = country.id;
            title = country.title;
        }
    }
}