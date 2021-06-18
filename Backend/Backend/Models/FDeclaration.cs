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
      public List<User> ShowUserSortName(List<User> peoples, int var);//1-Возрастание 2-убвание
      public List<OrderInfo> ShowClientOrder(List<Order> ord, long IdClient);
       public List<Order> GetOneOrderForEdit(List<Order> ord, long IdOrder);


        public List<Furniture> ShowMyFurniture(List<Order> ord, int IdOrder);
    }
}
