using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vk.Models.Database
{
    public class AuthTokenVk
    {
        public int Id { get; set; }

        public string TokenValue { get; set; } = string.Empty;

        public DateTime DateTime { get; set; }
    }
}