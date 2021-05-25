using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public interface FDeclaration
    {
      public List<OrderInfo> ShowAllOrder(List<Order> ord);
      public List<OrderInfo> ShowExpensiveOrder(List<Order> ord);
      public List<OrderInfo> ShowExpensiveOrder2(List<Order> ord, int k);
      public List<System.Linq.IGrouping<string, Order>> ShowOrderByAddress(List<Order> ord);
     // public List<OrderInfo> ShowOrderByAddress(List<Order> ord, string address);
      public List<User> ShowUserSortName(List<User> peoples, int var);//1-Возрастание 2-убвание

    }
}
