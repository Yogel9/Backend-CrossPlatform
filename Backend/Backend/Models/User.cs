using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
