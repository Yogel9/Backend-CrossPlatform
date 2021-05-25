using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Furniture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public float Price { get; set; }
        public int SizeX { get; set; } = 1;
        public int SizeY { get; set; } = 1;
        public int SizeZ { get; set; } = 1;
        // public long OrderId { get; set; }
    }
}
