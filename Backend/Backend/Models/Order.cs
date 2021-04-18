using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public User Сlient { get; set; } // покупатель
        public string Address { get; set; } // адрес доставки
        public float Price { get; set; }
        public List<Furniture> Furnitures { get; set; } //вся ммебель в заказе



        public int NumberOfFurnitures
        {
            get
            {
                return Furnitures.Count();
            }

        }

        public class OrderInfo
        {
            public int OrderId { get; set; }
            public string NameOfClient { get; set; }
            public string Address { get; set; }
            public float Price { get; set; }
            public int NumberOfFurnitures { get; set; }
            public int ClientId { get; set; }


        }
        public OrderInfo GetOrderInfo()
        {
            OrderInfo ordInf = new OrderInfo();
            ordInf.OrderId = OrderId;
            ordInf.NameOfClient = Сlient.Name;
            ordInf.Address = Address;
            ordInf.Price = Price;
            ordInf.NumberOfFurnitures = NumberOfFurnitures;
            return ordInf;
        }
    }
}
