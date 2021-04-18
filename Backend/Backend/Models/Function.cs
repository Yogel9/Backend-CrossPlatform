using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Function : FDeclaration
    {

        List<OrderInfo> ShowAllOrder(List<Order> ord)
        {
            return ord.Select(a=> new OrderInfo
            {
               OrderId= a.OrderId,
               NameOfClient=a.NameOfClient,
               Address= a.Address,
               Price=a.Price,
               NumberOfFurnitures= a.NumberOfFurnitures ,
               ClientId= a.ClientId
            }).ToList();
        }


       






    }
}
