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
            return ord.Select(a=> new OrderInfo
            {
               OrderId= a.OrderId,
               NameOfClient = a.Сlient.Name,
               Address = a.Address,
               Price=a.Price,
               NumberOfFurnitures= a.NumberOfFurnitures 
            }).ToList();
        }


        public List<OrderInfo> ShowExpensiveOrder(List<Order> ord)
        {
            
           return ord.Where(a => a.Price >= 100).Select(t => new OrderInfo
            {
                OrderId = t.OrderId,
                NameOfClient = t.Сlient.Name,
                Address = t.Address,
                Price = t.Price,
                NumberOfFurnitures = t.NumberOfFurnitures
            }
            ).ToList();
        }

        public List<OrderInfo> ShowExpensiveOrder2(List<Order> ord,int k)
        {

            return ord.Where(a => a.Price >= k).Select(t => new OrderInfo
            {
                OrderId = t.OrderId,
                NameOfClient = t.Сlient.Name,
                Address = t.Address,
                Price = t.Price,
                NumberOfFurnitures = t.NumberOfFurnitures
            }
             ).ToList();
        }



        public List<OrderInfo> ShowOrderByAddress(List<Order> ord,string address)
        {

            return ord.Where(a => a.Address == address).Select(t => new OrderInfo
            {
                OrderId = t.OrderId,
                NameOfClient = t.Сlient.Name,
                Address = t.Address,
                Price = t.Price,
                NumberOfFurnitures = t.NumberOfFurnitures
            }
             ).ToList();
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
