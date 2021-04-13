using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string User { get; set; } // имя фамилия покупателя
        public string Address { get; set; } // адрес покупател
      
       // public int FurnitureId { get; set; } // ссылка на связанную модель Furniture
        public Furniture Furniture { get; set; }
    }
}
