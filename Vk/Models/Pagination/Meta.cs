using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Pagination
{
    public class Meta
    {
        public int total { get; set; }

        public int elementsPerPage { get; set; }

        public int pageNumber { get; set; }
    }
}