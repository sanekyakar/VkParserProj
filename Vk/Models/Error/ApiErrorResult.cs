using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Error
{
    public class ApiErrorResult
    {
        public string GlobalError { get; set; } = string.Empty;

        public List<ApiFieldError> FieldErrors { get; set; } = new List<ApiFieldError>();
    }
}