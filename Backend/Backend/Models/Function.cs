using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Function : FDeclaration
    {
        public List<OrderInfo> ShowAllOrder(List<Order> ord)
        {
            return ord.Select(a => new OrderInfo
            {
                OrderId = a.OrderId,
                NameOfClient = a.Сlient.Name,
                Address = a.Address,
                Price = a.Price,
                NumberOfFurnitures = a.NumberOfFurnitures,
                DeliveryType = a.DeliveryType,
                PriceDelivery = a.PriceDelivery
            }).ToList();
        }


        public List<OrderInfo> ShowExpensiveOrder(List<Order> ord)
        {

            return ord.Where(t => t.Price >= 100).Select(a => new OrderInfo
            {
                OrderId = a.OrderId,
                NameOfClient = a.Сlient.Name,
                Address = a.Address,
                Price = a.Price,
                NumberOfFurnitures = a.NumberOfFurnitures,
                DeliveryType = a.DeliveryType,
                PriceDelivery = a.PriceDelivery
            }
            ).ToList();
        }

        public List<OrderInfo> ShowExpensiveOrder2(List<Order> ord, int k)
        {

            return ord.Where(a => a.Price >= k).Select(t => new OrderInfo
            {
                OrderId = t.OrderId,
                NameOfClient = t.Сlient.Name,
                Address = t.Address,
                Price = t.Price,
                NumberOfFurnitures = t.NumberOfFurnitures,
                DeliveryType = t.DeliveryType,
                PriceDelivery = t.PriceDelivery
            }
             ).ToList();
        }

        public List<OrderInfo> ShowClientOrder(List<Order> ord, long IdClient)
        {

            return ord.Where(a => a.Сlient.UserId == IdClient).Select(t => new OrderInfo
            {
                OrderId = t.OrderId,
                NameOfClient = t.Сlient.Name,
                Address = t.Address,
                Price = t.Price,
                NumberOfFurnitures = t.NumberOfFurnitures,
                DeliveryType = t.DeliveryType,
                PriceDelivery = t.PriceDelivery
            }
             ).ToList();
        }

         public List<Furniture> ShowMyFurniture(List<Order> ord, int IdOrder)
        {
            List<Furniture> arm =  new List<Furniture>();
        
            foreach (Furniture i in ord[IdOrder].Furnitures)
            {
                arm.Add(i);
            }

            return  arm;
            

            //    Id = t.Furnitures[],
            //Name
            //Company
            //Price
            //SizeX
            //SizeY
            //SizeZ
             
        }

        public List<Order> GetOneOrderForEdit(List<Order> ord, long IdOrder)
        {
         return ord.Where(a => a.OrderId == IdOrder).Select(t => new Order {
          OrderId= t.OrderId,
          Сlient=  t.Сlient,
          Address=t.Address, 
          DeliveryType=t.DeliveryType, 
          Furnitures=t.Furnitures,
         }).ToList();
        }

   


        public List<User> ShowUserSortName(List<User> peoples,int var)//1-Возрастание 2-убвание
        {
            if (var == 1)
            { return peoples.OrderBy (a => a.Name).ToList(); }
            else 
            {
               return peoples.OrderByDescending (a => a.Name).ToList();
            }
            //ascending//возрастание
            //descending//Убывание
        }
    }
}
