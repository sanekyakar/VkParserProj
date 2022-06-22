using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Error
{
    public class ApiFieldError
    {
        public string FieldName { get; set; } = string.Empty;

        public string FielError { get; set; } = string.Empty;
    }
}