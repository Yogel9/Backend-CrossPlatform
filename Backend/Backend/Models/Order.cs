using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public User Сlient { get; set; } // покупатель (не получается заполнить через постман)
        public string Address { get; set; } // адрес доставки
        public float Price { get; set; }
        public List<Furniture> Furnitures { get; set; } = new List<Furniture> ();//вся ммебель в заказе
        public int NumberOfFurnitures
        {
            get
            {
                return Furnitures.Count();
            }
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
        public OrderAndCost GetOrderInfoCost()
        {
            OrderAndCost ordcost = new OrderAndCost();
            ordcost.OrderId = OrderId;
            ordcost.Price = Price;
            return ordcost;
        }

    }

    public class OrderInfo
    {
        public int OrderId { get; set; }
        public string NameOfClient { get; set; }
        public string Address { get; set; }
        public float Price { get; set; }
        public int NumberOfFurnitures { get; set; }
    }

    public class OrderAndCost
    {
        public int OrderId { get; set; }
        public float Price { get; set; }
    }
}
